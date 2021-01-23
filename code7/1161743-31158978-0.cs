    HttpListenerContext context = listener.GetContext();
    HttpListenerRequest request= context.Request;
    HttpListenerResponse response = context.Response;
    // Process Request **First**
    String url = request.RawUrl;
    String[] queryStringArray = url.Split('/');
    String postedtext = GetPostedText(request);                   
    // Process Response **Second**
    string html = Properties.Resources.index;
    byte[] webPageBuffer = Encoding.UTF8.GetBytes(html);
    response.ContentLength64 = webPageBuffer.Length;
    ouputStream = response.OutputStream;
    ouputStream.Write(webPageBuffer, 0, webPageBuffer.Length);
    ouputStream.Flush();
    /* etc */
