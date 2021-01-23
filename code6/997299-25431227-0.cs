       // Grab the contents of the request.
       Stream s = filterContext.RequestContext.HttpContext.Request.InputStream;
       byte[] data = new byte[s.Length];
       s.Read(data, 0, (int)s.Length);
       string rawData = Encoding.UTF8.GetString(data);
       // And process it into something nice and readable.
       IEnumerable<string> fields = (from x in rawData.Split('&') select  HttpUtility.UrlDecode(x));
       string formatted = string.Join(Environment.NewLine, fields);
