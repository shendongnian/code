    // This class writes to two different outputs, one of which can be the log
    public class LoggingConsoleWriter : TextWriter
    {
        private readonly TextWriter _output;
        private readonly TextWriter _log;
        public LoggingConsoleWriter(TextWriter output, TextWriter log)
        {
            _output = output;
            _log = log;
        }
        public override void Write(char value)
        {
            _output.Write(value);
            _log.Write(value);
        }
        public override Encoding Encoding => _output.Encoding;
    } 
    class Program
    {
        static void Main(string[] args)
        {
            var logOutput = new StreamWriter(File.OpenWrite("log.txt"));
            var newOutput = new LoggingConsoleWriter(Console.Out, logOutput);
            
            // Redirect all Console.WriteX calls to write to newOutput
            Console.SetOut(newOutput);
            
            // This call will write to logOutput and the original Console.Out
            // through the LoggingConsoleWriter
            Console.WriteLine("Hello");
        }
    }
