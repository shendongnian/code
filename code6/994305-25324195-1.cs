    class MediaServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, byte[]> _responderMethod;
        public MediaServer(Func<HttpListenerRequest, byte[]> method, string prefix)
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");
            if (prefix == null)
                throw new ArgumentException("prefix");
            if (method == null)
                throw new ArgumentException("method");
            _listener.Prefixes.Add(prefix);
            _responderMethod = method;
            _listener.Start();
        }
        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                byte[] buf = _responderMethod(ctx.Request);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.ContentType = "application/octet-stream";
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch { }
                            finally
                            {
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch { }
            });
        }
        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }
    }
