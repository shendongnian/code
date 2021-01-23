    public partial class AsyncHandler : IHttpAsyncHandler
    {
        async Task CopyAsync(HttpContext context)
        {
            using (var stream = await GetContentAsync(context))
            {
                await stream.CopyToAsync(context.Response.OutputStream);
            }
        }
        #region IHttpAsyncHandler
        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            return new AsyncResult(extraData, cb, CopyAsync(context));
        }
        public void EndProcessRequest(IAsyncResult result)
        {
            // at this point, the task has compeleted
            // we use Wait() only to re-throw any errors
            ((AsyncResult)result).Task.Wait();
        }
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region AsyncResult
        class AsyncResult : IAsyncResult
        {
            object _state;
            Task _task;
            bool _completedSynchronously;
            public AsyncResult(object state, AsyncCallback callback, Task task)
            {
                _state = state;
                _completedSynchronously = _task.IsCompleted;
                _task = task;
                _task.ContinueWith(t => callback(this), TaskContinuationOptions.ExecuteSynchronously);
            }
            public Task Task
            {
                get { return _task; }
            }
            #region IAsyncResult
            public object AsyncState
            {
                get { return _state; }
            }
            public System.Threading.WaitHandle AsyncWaitHandle
            {
                get { return ((IAsyncResult)_task).AsyncWaitHandle; }
            }
            public bool CompletedSynchronously
            {
                get { return _completedSynchronously; }
            }
            public bool IsCompleted
            {
                get { return _task.IsCompleted; }
            }
            #endregion
        }
        #endregion
    }
