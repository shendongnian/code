    class Program
    {
        private static TraceSource mySource =
            new TraceSource("MyTraceSourceApp", SourceLevels.Information);
        private static TraceListener myListener =
            new MyTraceListener { TraceOutputOptions = TraceOptions.None };
        static void Main(string[] args)
        {
            mySource.Listeners.Add(myListener);
            mySource.TraceEvent(TraceEventType.Information, 1, "Hello Trace");
            Console.ReadLine();  // pause so we can see the output
        }
    }
    class MyTraceListener : ConsoleTraceListener
    {
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            Console.WriteLine(message);
        }
    }
