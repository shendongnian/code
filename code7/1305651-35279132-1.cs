    public class AdjustCasingModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.BeginRequest += OnBeginRequest;
        }
        
        protected void BeginRequest(object sender, EventArgs e)
        {
            var httpContext = ((HttpApplication)sender).Context;
            string[] path = httpContext.Request.Path.Split('/');
            if (path[1].Length > 0)
            {
                Regex rgx = new Regex(@"^[A-Z][a-z]*[A-Z]");
                if (!rgx.IsMatch(path[1]))
                {
                    char[] a = path[1].ToLower().ToCharArray();
                    a[0] = char.ToUpper(a[0]);
                    a[char.Length - 1] = char.ToUpper(a[char.Length - 1]);
                    path[1] = new string(a);
                    httpContext.RewritePath(String.Join('/', path));
                }
            }
        }
    
        public void Dispose()
        {
        }
    }
