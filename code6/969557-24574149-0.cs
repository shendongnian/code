    StackTrace st = new StackTrace(1, true);
                StackFrame[] stFrames = st.GetFrames();
                foreach (StackFrame sf in stFrames)
                {
                    Console.WriteLine(sf.GetMethod());
                }
                if ((new StackTrace(true).GetFrame(0) != null && new StackTrace(true).GetFrame(0).GetMethod().Name == "UpdateFromLocationInfo"))
                {
                }
                else
                {
                }
