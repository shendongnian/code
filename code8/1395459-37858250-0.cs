    public class IOMiddleware
    {
        private readonly RequestDelegate _next;
        public IOMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context.Request);
            await LogResponseAndInvokeNext(context);
        }
        private async Task LogRequest(HttpRequest request)
        {
            using (var bodyReader = new StreamReader(request.Body))
            {
                string body = await bodyReader.ReadToEndAsync();
                request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
                System.Diagnostics.Debug.Print(body);
            }
        }
        private async Task LogResponseAndInvokeNext(HttpContext context)
        {
            using (var buffer = new MemoryStream())
            {
                //replace the context response with our buffer
                var stream = context.Response.Body;
                context.Response.Body = buffer;
                //invoke the rest of the pipeline
                await _next.Invoke(context);
                //reset the buffer and read out the contents
                buffer.Seek(0, SeekOrigin.Begin);
                var reader = new StreamReader(buffer);
                using (var bufferReader = new StreamReader(buffer))
                {
                    string body = await bufferReader.ReadToEndAsync();
                    //reset to start of stream
                    buffer.Seek(0, SeekOrigin.Begin);
                    //copy our content to the original stream and put it back
                    await buffer.CopyToAsync(stream);
                    context.Response.Body = stream;
                    System.Diagnostics.Debug.Print($"Response: {body}");
                }
            }
        }
    }
