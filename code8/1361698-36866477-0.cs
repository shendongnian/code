    public class NoisyTracer : TextWriterTraceListener
    {
        public static void Install()
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add (new NoisyTracer (Console.Out));
        }
    
        public NoisyTracer (TextWriter writer) : base (writer) { }
    
        public override void Fail (string message, string detailMessage)
        {
            base.Fail (message, detailMessage);
            throw new Exception ("Trace failure: " + message);
        }
    }
