        public bool IsReusable { get { return true; }}
        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            return new AsynchOperation(cb, context, extraData).Start();
        }
        public void EndProcessRequest(IAsyncResult result) { }
        public void ProcessRequest(HttpContext context) { }
        private class AsynchOperation : IAsyncResult
        {
            private AsyncCallback cb;
            private HttpContext context;
            public WaitHandle AsyncWaitHandle { get { return null; } }
            public object AsyncState { get; private set; }
            public bool IsCompleted { get; private set; }
            public bool CompletedSynchronously { get { return false; } }
            public AsynchOperation(AsyncCallback callback, HttpContext context, object state)
            {
                cb = callback;
                this.context = context;
                AsyncState = state;
                IsCompleted = false;
            }
            public IAsyncResult Start()
            {
                ThreadPool.QueueUserWorkItem(AsyncWork, null);
                return this;
            }
            private void AsyncWork(object _)
            {
                var request = (HttpWebRequest)WebRequest.Create(boshUri);
                request.Method = context.Request.HttpMethod;
                // copy headers & body
                request.UserAgent = context.Request.UserAgent;
                request.Accept = string.Join(",", context.Request.AcceptTypes);
                if (!string.IsNullOrEmpty(context.Request.Headers["Accept-Encoding"]))
                {
                    request.Headers["Accept-Encoding"] = context.Request.Headers["Accept-Encoding"];
                }
                request.ContentType = context.Request.ContentType;
                request.ContentLength = context.Request.ContentLength;
                using (var stream = request.GetRequestStream())
                {
                    CopyStream(context.Request.InputStream, stream);
                }
                request.BeginGetResponse(EndGetResponse, Tuple.Create(context, request));
            }
            private void EndGetResponse(IAsyncResult ar)
            {
                var data = (Tuple<HttpContext, HttpWebRequest>)ar.AsyncState;
                var context = data.Item1;
                var request = data.Item2;
                try
                {
                    using (var response = request.EndGetResponse(ar))
                    {
                        context.Response.ContentType = response.ContentType;
                        // copy headers & body
                        foreach (string h in response.Headers)
                        {
                            context.Response.AppendHeader(h, response.Headers[h]);
                        }
                        using (var stream = response.GetResponseStream())
                        {
                            CopyStream(stream, context.Response.OutputStream);
                        }
                        context.Response.Flush();
                    }
                }
                catch (Exception err)
                {
                    if (err is IOException || err.InnerException is IOException)
                    {
                        // ignore
                    }
                    else
                    {
                        LogManager.GetLogger("ASC.Web.BOSH").Error(err);
                    }
                }
                finally
                {
                    IsCompleted = true;
                    cb(this);
                }
            }
