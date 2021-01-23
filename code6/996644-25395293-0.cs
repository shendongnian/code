    public static void ListenerCallback(IAsyncResult result)
    {
        HttpListener listener = (HttpListener)result.AsyncState;
        HttpListenerContext context = listener.EndGetContext(result);
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;
		using (var out = File.OpenWrite("output.pptx"))
		{
			request.InputStream.CopyTo(out);
		}
        response.StatusCode = 200;
        response.ContentType = "text/html";
        using (StreamWriter writer = new StreamWriter(context.Response.OutputStream, Encoding.UTF8))
            writer.WriteLine("File Uploaded");
        response.Close();
    }
