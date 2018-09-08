﻿using System;

namespace _01ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //The two application modules that require information
            //they are the observers: (Observers)

            //logging
            var log = new Logger();

            //and user interface
            var ui = new UserInterface();

            //the long-term process
            var process = new LongRunningProcess();

            process.ObserversCallList += log.Message;
            process.ObserversCallList += ui.Message;

            /// Problems:
            /// 
            ///  1. I can initialize the call list from the outside
            ///  process.ObserversCallList = null;
            ///  
            /// 2. I can call the call list from outside
            /// process.ObserversCallList(new LongRunningProcess());

            process.Start();

            process.ObserversCallList -= log.Message;
            process.ObserversCallList -= ui.Message;

            Console.WriteLine("The process is done.");

            Console.ReadLine();
        }
    }
}
