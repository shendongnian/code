    public void ProcessRequest(HttpContext context)
    {
        Response.ContentType = "text/event-stream";
         
        while (true)
        {
            if (NewEventAvailable())
            {
                context.Response.Write("Some new event data");
                context.Response.Flush();
            }
         
            System.Threading.Thread.Sleep(1000);
        }
         
        Response.Close();
    }
