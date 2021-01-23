      public async Task Invoke(HttpContext context)
        {
            //Workaround - copy original Stream
            var initalBody = context.Request.Body;
            using (var bodyReader = new StreamReader(request.Body))
            {
                string body = await bodyReader.ReadToEndAsync();
                //Do something with body
                //Replace write only request body with read/write memorystream so you can read from it later
                   request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
            
            //handle other middlewares
            await _next.Invoke(context);
            //Workaround - return back to original Stream
            context.Request.Body = initalBody;
        }
