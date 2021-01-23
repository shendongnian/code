    public static void WriteToLog(string _logstring)
    {
                string filepath = @"C:\myFilePath\fileName"
    
                Trace.Listeners.Clear();
    
                TextWriterTraceListener twtl = new TextWriterTraceListener(filepath + ".log");
                ConsoleTraceListener ctl = new ConsoleTraceListener(false);
    
                Trace.Listeners.Add(twtl);
                Trace.Listeners.Add(ctl);
                Trace.AutoFlush = true;
                Trace.WriteLine(_logstring);
    }
