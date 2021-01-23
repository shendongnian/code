     class Program
        {
            private static bool _isToBreakTheLoop = false;
            static void Main(string[] args)
            {
                Console.CancelKeyPress += Console_CancelKeyPress;
    
                while (true)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("..");
    
                    if (_isToBreakTheLoop) break;
                }
            }
       
            private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                _isToBreakTheLoop = true;
                Console.WriteLine("Cancel key trapped. Execution will not terminate.");
            }
        }
