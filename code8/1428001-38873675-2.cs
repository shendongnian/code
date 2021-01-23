    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    
    namespace Common
    {
    	// changed sealed to static as there are no instances
        public sealed class LoggerDebug
        {
            // removed lock object 
            private static Logger log;
    
    		// added static constructor
    		static LoggerDebug(){
    			log = new Logger();
				_logger = new LoggerDebug();
    		}
			
			// singleton that is created only once
			private static LoggerDebug _logger;
			public static LoggerDebug Logger{
				get{return _logger;}
			}
    		
            // removed static keyword
            public void Write(String EventType, string appSource, string text)
            {
                log.Write(EventType, appSource, string.Format("Test {0}", text));
            }
        }
    }
