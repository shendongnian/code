    class CustomTraceListener : TraceListener
    {
        public string  AllMessages { get; set; }
        public override void Write(string message)
        {
            AllMessages += message;
        }
        public override void WriteLine(string o)
        {
            Write(o + '\n');
        }
        public override string ToString()
        {
            return AllMessages;
        }
    }
