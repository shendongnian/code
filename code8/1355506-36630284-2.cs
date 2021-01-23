    class Program
    {
        static void Main(string[] args)
        {
            var sw = new StringWriter();
            var newOutput = new LoggingConsoleWriter(Console.Out, logOutput);
            
            // Redirect all Console.WriteX calls to write to newOutput
            Console.SetOut(newOutput);
            
            // This call will write to the StringWriter and the original Console.Out
            // through the LoggingConsoleWriter
            Console.WriteLine("Hello");
            // Retrieve the currently written values
            string output = sw.GetStringBuilder().ToString();
        }
    }
