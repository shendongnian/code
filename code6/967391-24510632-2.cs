    var outputStream = context.Response.OutputStream;
    GetContent().ContinueWith(task => 
    {
        using (var stream = task.Result)
        {
            stream.WriteTo(outputStream);
        }
    });
