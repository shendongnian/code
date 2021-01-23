    public bool Listening = true;
    public static void GetContext()
    {
        while (Listening)
        {
            // De GetContext methode blokkeert terwijl die wacht op een aanvraag(request)
            HttpListenerContext context = _listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            string html = Properties.Resources.index;
            byte[] buffer = Encoding.UTF8.GetBytes(html);
            response.ContentLength64 = buffer.Length;
            _ouput = response.OutputStream;
            _ouput.Write(buffer, 0, buffer.Length);
        }
    }
