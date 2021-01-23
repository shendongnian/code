    public class RemotePost
    {
        private string url;
        private string method;
        private Dictionary<string, string> inputs;
    
        public string Url
        {
            set { url = value; }
            get { return url; }
        }
        public string Method
        {
            set { method = value; }
            get { return method; }
        }
        public Dictionary<string, string> Inputs
        {
            set { inputs = value; }
            get { return inputs; }
        }
    
    
        public RemotePost(string url, string method = "post")
        {
            Url = url;
            Method = method;
            Inputs = new Dictionary<string, string>();
        }
        public void PostAndRedirect()
        {
            var postString = new StringBuilder();
            postString.Append("<html><head>");
            postString.Append("</head><body onload=\"document.form1.submit();\">");
            postString.Append("<form name=\"form1\" method=\"" + Method + "\" action=\"" + Url + "\" >");
    
            foreach (KeyValuePair<string, string> oPar in Inputs)
                postString.Append(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", oPar.Key, oPar.Value));
    
            postString.Append("</form>");
            postString.Append("</body></html>");
    
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(postString.ToString());
            HttpContext.Current.Response.End();
        }
        public void Add(string name, string value)
        {
            lock (Inputs)
                Inputs.Add(name, value);
        }
    }
