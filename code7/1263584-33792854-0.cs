            // Declare a delegate that takes a single string parameter
            // and has no return type.
            public delegate voidLogHandler(string message);
    
            // The use of the delegate is just like calling a function directly,
            // though we need to add a check to see if the delegate is null
            // (that is, not pointing to a function) before calling the function.
            public void Process(LogHandlerlogHandler)
            {
                if (logHandler != null)
                {
                    logHandler("Process() begin");
                }
    
                if (logHandler != null)
                {
                    logHandler ("Process() end");
                }
            }
        }
    
        // Test Application to use the defined Delegate
        public class TestApplication
        {
            // Static Function: To which is used in the Delegate. To call the Process()
            // function, we need to declare a logging function: Logger() that matches
            // the signature of the delegate.
            static void Logger(string s)
            {
                Console.WriteLine(s);
            }
    
            static void Main(string[] args)
            {
                MyClass myClass = new MyClass();
    
                // Crate an instance of the delegate, pointing to the logging function.
                // This delegate will then be passed to the Process() function.
                MyClass.LogHandler myLogger = new MyClass.LogHandler(Logger);
                myClass.Process(myLogger);
            }
        }
