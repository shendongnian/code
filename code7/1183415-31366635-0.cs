        static void Main(string[] args) {
            if (!System.Diagnostics.Debugger.IsAttached) {
                AppDomain.CurrentDomain.UnhandledException += ReportUnhandledException;
            }
            // Rest of code
            //...
            throw new Exception("Kaboom");   // Test
        }
        private static void ReportUnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Console.WriteLine();
            Console.WriteLine("We're very sorry, this program unexpectedly failed.");
            Console.WriteLine("Please include the following information in your support request:");
            Console.WriteLine();
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine();
            Console.Write("Please press any key to end the program");
            Console.ReadKey();
            Environment.Exit(1);
        }
