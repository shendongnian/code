        public class PerfMesureHandler: IDisposable
            {
                private PerfMesureHandler(string topic, string methodName , int lineNumber )
                {
        #if DEBUG
                    _methodName = methodName;
                    _lineNumber = lineNumber;
                    _topic = topic;   
                    _stopwatch = new Stopwatch();
                    _stopwatch.Start();
        #endif
                }
                private string _topic;
                private static PerfMesureHandler_singleton;
                private Stopwatch _stopwatch;
                private int _lineNumber;
                private string _methodName;
        
        
                public static PerfMesureHandler Start(string topic, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
                {
                    PerfMesureHandler= null;
        #if DEBUG
                    result = new PerfMesureHandler(topic, methodName, lineNumber);
        #else
                    if (_singleton == null)
                    {
                        _singleton = new PerfMesureHandler(topic, methodName, lineNumber);
                    }
                    result = _singleton;       
        #endif
                    return result;
                }
        
            public void Dispose()
            {
    #if DEBUG
                _stopwatch.Stop();
    			//Write to log...
    			string msg = $"topic: {_topic}, time:  {_stopwatch.ElapsedMilliseconds}, method: {_methodName}, line: {_lineNumber}";
    			Console.WriteLine(msg)
    #endif
            }        
}
