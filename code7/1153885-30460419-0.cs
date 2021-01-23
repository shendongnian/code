    public class SampleEvent
    {
        public SampleEvent(int lineNumber)
	    {
            LineNumber = lineNumber;
	    }
        public int LineNumber { get; private set; }
    }
