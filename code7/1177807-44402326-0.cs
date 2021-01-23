    public class HttpModule : IHttpModule
    {
        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += ContextBeginRequest;
        }
        private void ContextBeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                //do stuff
            }
        }
        void IHttpModule.Dispose()
        {
            // Nothing to dispose; 
        }
    }
