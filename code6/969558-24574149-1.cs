            // Create a StackTrace that captures filename, line number, and column 
            // information for the current thread.
                StackTrace st = new StackTrace(true);
                StackFrame[] stFrames = st.GetFrames();
                foreach (StackFrame sf in stFrames)
                {
                    Console.WriteLine(sf.GetMethod());
                }
              //The StackFrame at array index 0 represents the most recent function call 
              // in the stack trace and the last 
              //frame pushed onto the call stack.
                if ((new StackTrace(true).GetFrame(0) != null && 
                new  StackTrace(true).GetFrame(0).GetMethod().Name == "UpdateFromLocationInfo"))
                {
                }
                else
                {
                }
       
