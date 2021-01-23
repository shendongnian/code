    public void ProcessRequest(HttpContext context)
    {
        Response.ContentType = "text/event-stream";
        var source = new SomeEventSource();
        source.OnSomeEvent += data =>
        {
            context.Response.Write(data);
            context.Response.Flush();
        }
        while (true)
        {
            System.Threading.Thread.Sleep(1000);
        }
         
        Response.Close();
    }
