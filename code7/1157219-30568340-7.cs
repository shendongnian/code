        private static void WriteX()
        {
            backgroundThreadReady.Set(); // inform your main thread that this thread is ready for the race
            startThreadRace.WaitOne();   // wait 'till the main thread starts the race
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(".");
            }
        }
