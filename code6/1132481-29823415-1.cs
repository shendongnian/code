        class OutputContext
        {
            public const int BufferSize = 1024;
            public bool IsEof { get; set; }
            public bool IsWaiting { get; set; }
            public byte[] Buffer { get; set; }
            public StreamReader Reader { get; set; }
            public object Tag { get; set; }
            public OutputContext(StreamReader r, object tag)
            {
                IsEof = false;
                IsWaiting = false;
                Buffer = new byte[BufferSize];
                Reader = r;
                Tag = tag;
            }
        }
        Process proc;
        void Callback(IAsyncResult ar)
        {
            lock (ar.AsyncState)
            {
                OutputContext ctx = ar.AsyncState as OutputContext;
                int c = ctx.Reader.BaseStream.EndRead(ar);
                ctx.IsWaiting = false;
                if (c == 0)
                {
                    ctx.IsEof = true;
                    return;
                }
                
                string content = Encoding.UTF8.GetString(ctx.Buffer, 0, c);
                Console.Write(content);
                Console.Out.Flush();
                
            }
        }
        void RedirectOutput(OutputContext ctx)
        {
            lock (ctx)
            {
                if (ctx.IsEof)
                {
                    return;
                }
            
                if (ctx.IsWaiting)
                {
                    return;
                }
                ctx.IsWaiting = true;
                IAsyncResult ar = ctx.Reader.BaseStream.BeginRead(ctx.Buffer, 0, 
                    OutputContext.BufferSize, Callback, ctx);
            }
        }
        void Run(string yourprog, string yourargs)
        {
            // If this is a GUI app, this shall not be run on the UI thread.
            // Spin a new thread to handle it and wait for the thread to complete.
            // And you can always accept the input as long as the UI thread is not
            // blocked, and redirect the input to the target proc's stdin asycly.
            proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = yourprog;
            proc.StartInfo.Arguments = yourargs;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.Start();
            OutputContext stdoutCtx = new OutputContext(proc.StandardOutput, "STDOUT");
            OutputContext stderrCtx = new OutputContext(proc.StandardError, "STDERR");
            while (!stdoutCtx.IsEof && !stderrCtx.IsEof)
            {
                RedirectOutput(stdoutCtx);
                RedirectOutput(stderrCtx);
            }
            proc.WaitForExit();
        }
    }
