        public class TrackingModule : IHttpModule
    {
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }
        void OnBeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpRequest request = app.Context.Request;
            if (request == null)
            {
                return;
            }
            string url = request.RawUrl;
            string userAddress = request.UserHostAddress;
            DateTime time = DateTime.UtcNow;
            string userAgent = request.UserAgent;
            // Store somewhere the data...
        }
    }
