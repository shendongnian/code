    public class TestHandler : IHttpAsyncHandler
    {
        private IHttpAsyncHandler _handler;
        public bool IsReusable
        {
            get { return false; }
        }
        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback callback, object state)
        {
            _handler = GetHttpHandler(context);
            return _handler.BeginProcessRequest(context, callback, state);
        }
        public void EndProcessRequest(IAsyncResult asyncResult)
        {
            _handler.EndProcessRequest(asyncResult);
        }
        public void ProcessRequest(HttpContext context)
        {
            throw new NotSupportedException();
        }
        IHttpAsyncHandler GetHttpHandler(HttpContext context)
        {
            return BuildManager.CreateInstanceFromVirtualPath("~/TestPage.aspx", typeof(Page)) as IHttpAsyncHandler;
        }
    }
