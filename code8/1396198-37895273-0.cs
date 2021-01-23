    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            void run()
            {
                Task.Factory.StartNew(resetFlagAfter1s);
                var waiter = Task.Factory.StartNew(waitForFlag);
                waiter.Wait();
                Console.WriteLine("Done");
            }
            void resetFlagAfter1s()
            {
                Thread.Sleep(1000);
                flag = false;
            }
            void waitForFlag()
            {
                int x = 0;
                while (flag)
                {
                    ++x;
                    // Uncommenting this line make this thread see the changed value of flag.
                    // Console.WriteLine("Spinning"); 
                }
            }
            // Uncommenting "volatile" makes waitForFlag() see the changed value of flag.
            /*volatile*/ bool flag = true;
            static void Main()
            {
                new Program().run();
            }
        }
    }
