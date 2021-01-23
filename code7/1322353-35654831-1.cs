    public class Logger
    {
    	private static Logger _logger;
            private TraceSource _ts;
    
            private Logger()
            {
    	    // Configure TraceSource here as required, e.g.
                _ts = new TraceSource("StackOverflow", SourceLevels.All);
                _ts.Listeners.Add(new TextWriterTraceListener(@"c:\temp\tracefile.log"));
            }
    
            public static Logger Get()
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                }
    
                return _logger;
            }
    
            public void TraceInfo(string message)
            {
                _ts.TraceInformation(message);
                _ts.Flush();
            }
    }
    
    // To use
    Logger.Get().TraceInfo("This is a trace message");
