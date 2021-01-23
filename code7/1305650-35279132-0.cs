    void Application_BeginRequest(Object sender, EventArgs e)
    {
        string[] path = HttpContext.Current.Request.Path.Split('/');
        if (path[1].Length > 0) {
            Regex rgx = new Regex(@"^\/[A-Z][a-z]*[A-Z]\/");
            if (!rgx.IsMatch(path[1])) {
                char[] a = path[1].ToLower().ToCharArray();
                a[0] = a[0].ToUpper();
                a[char.Length - 1] = a[char.Length - 1].ToUpper();
                path[1] = new string(a);
                HttpContext.Current.RewritePath(String.Join('/', path));
            }
        }              
    }    
