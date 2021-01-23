    class Program
        {
            static void Main(string[] args)
            {
                Console.CancelKeyPress += Console_CancelKeyPress;
    
                while (true)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("..");
                }
            }
    
    
            private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                Console.WriteLine("Cancel key trapped. Execution will not terminate.");
            }
        }
