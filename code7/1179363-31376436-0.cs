            Trace.Listeners.Clear();
            TextWriterTraceListener twtl = new TextWriterTraceListener(pathBuildDir + @"\log.txt");
            twtl.Name = "TextLogger";
            twtl.TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime;
            ConsoleTraceListener ctl = new ConsoleTraceListener(false);
            ctl.TraceOutputOptions = TraceOptions.DateTime;
            Trace.Listeners.Add(twtl);
            Trace.Listeners.Add(ctl);
            Trace.AutoFlush = true;
            MLApp.MLApp matlab = new MLApp.MLApp();
            Trace.WriteLine(matlab.Execute("pwd"));
            Trace.WriteLine(matlab.Execute(@"run('foobar.m')"));
            ...
            ...
