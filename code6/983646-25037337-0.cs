    public class AdServerModule : IHttpModule
    {
        public void OnBeginRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            var queryString = context.Request.QueryString;
            var readonlyProperty = queryString.GetType().GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            readonlyProperty.SetValue(queryString, false, null);
            queryString.Add("foo", "bar");
            var path = GetVirtualPath(context);
            context.RewritePath(path, String.Empty, queryString.ToString());
            readonlyProperty.SetValue(queryString, true, null);
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OnBeginRequest);
        }
        private static string GetVirtualPath(HttpContext context)
        {
            string path = context.Request.RawUrl;
            var queryStringLength = path.IndexOf("?");
            path = path.Substring(0, queryStringLength >= 0 ? queryStringLength : path.Length);
            path = path.Substring(path.LastIndexOf("/") + 1);
            return path;
        }
    }
