    public class ConsoleTraceListener : TextWriterTraceListener
    {
        public ConsoleTraceListener() : base(new CustomTextWriter())
        {
        }
        public override void Close()
        {
        }
    }
