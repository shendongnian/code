    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    
    namespace Common
    {
    	// changed sealed to static as there are no instances
        public static class LoggerDebug
        {
            // instance of LoggerDebug as it is now static
            // removed lock object 
            private static Logger log;
    
    		// added static constructor
    		static LoggerDebug(){
    			log = new Logger();
    		}
    		
    		// no need for lock due to static constructor
			// removed Instance
    		// removed instance constructor
    
            public static void Write(String EventType, string appSource, string text)
            {
                log.Write(EventType, appSource, string.Format("Test {0}", text));
            }
        }
    }
