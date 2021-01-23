        class Program
        {
            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
                Thread.CurrentThread.Name = "Main";
                ThreadPool.QueueUserWorkItem(Corrupt, Thread.CurrentThread);
                ThreadPool.QueueUserWorkItem(RunMethod);
                Console.ReadLine();
            }
    
            private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.ExceptionObject);
            }
    
            private static void Corrupt(object state)
            {
                unsafe
                {
                    var thread = (Thread)state;
                    fixed (char* str = thread.Name)
                    {
                        char* increment = str;
                        char* decrement = str;
                        while (true)
                        {
                           *(decrement--) = 'f';
                            *(increment++) = 'b';
                            Thread.Sleep(10);
                        }
                    }
                }
            }
    
            [HandleProcessCorruptedStateExceptions ]
            public static void RunMethod(object state)
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("I'm Alive");
                        Thread.Sleep(5000);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);   
                }
            }
        }
