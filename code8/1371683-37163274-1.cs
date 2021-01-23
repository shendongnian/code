    public class UserDoSomethingClass
    {
        private readonly ITraceWriter writer;
        public UserDoSomethingClass(ITraceWriter writer)
        {
            this.writer = writer;
        }
        public void DoSomething()
        {
            // the user did something.
            this.writer.TraceInfo("did something");
        }
    }
