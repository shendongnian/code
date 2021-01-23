        private static AutoResetEvent signal = new AutoResetEvent(false);
        private volatile static bool interruptFlag;
        private volatile static bool abortFlag;
        private static void Process()
        {
            //replace true with your condition
            while (true)
            {
                if (interruptFlag)
                {
                    if (signal.WaitOne())
                    {
                        if (abortFlag)
                        {
                            Console.WriteLine("exiting");
                            return;
                        }
                    }
                }
                Console.WriteLine("doing work");
                //.. important work here
            } 
        }
        private static void Interrupt() {
            ConsoleKeyInfo c = Console.ReadKey();
            if (c.Key == ConsoleKey.Enter) {
                interruptFlag = true;
                // Should Pause The First Thread Here And Ask To Continue/Resume Or Kill
                c = Console.ReadKey();
                if (c.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Interrupting");
                    abortFlag = true;
                    signal.Set();
                }
                else
                {
                    Console.WriteLine("Continuing");
                    interruptFlag = false;
                    abortFlag = false;
                    signal.Set();
                }
            }
        }
        static void Main()
        {
            Thread process = new Thread(Process);
            process.Start();
            Thread interrupt = new Thread(Interrupt);
            interrupt.Start();
            
        }
