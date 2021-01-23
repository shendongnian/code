    sealed class StackOverflowSampleListener : TraceListener
    {
        // Singleton 
        public static readonly StackOverflowSampleListener Instance =
          new StackOverflowSampleListener();
        public void InitializeTracing(bool ReadDebugOutput)
        {
             if (ReadDebugOutput == true)
                Debug.Listeners.Add(this);
            else
                Trace.Listeners.Add(this);
        }
        public StringBuilder Buffer = new StringBuilder();
        public override void Write(string message)
        {
            // Do something with your messages!
            Buffer.Append(message);
        }
        public override void WriteLine(string message)
        {
            // Do something with your messages!
            Buffer.Append(message);
        }
    }
