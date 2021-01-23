    internal class FileReplacementMiddleware : OwinMiddleware
    {
        public FileReplacementMiddleware(OwinMiddleware next) : base(next) {}
        public override async Task Invoke(IOwinContext context)
        {
            MemoryStream memStream = null;
            Stream httpStream = null;
            if (ShouldAmendResponse(context))
            {
                memStream = new MemoryStream();
                httpStream = context.Response.Body;
                context.Response.Body = memStream;
            }
            await Next.Invoke(context);
            if (memStream != null)
            {
                var content = await ReadStreamAsync(memStream);
                if (context.Response.StatusCode == 200)
                {
                    content = AmendContent(context, content);
                }
                var contentBytes = Encoding.UTF8.GetBytes(content);
                context.Response.Body = httpStream;
                context.Response.ETag = null;
                context.Response.ContentLength = contentBytes.Length;
                await context.Response.WriteAsync(contentBytes, context.Request.CallCancelled);
            }
        }
        private static async Task<string> ReadStreamAsync(MemoryStream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
        private bool ShouldAmendResponse(IOwinContext context)
        {
            // logic
        }
        private string AmendContent(IOwinContext context, string content)
        {
            // logic
        }
    }
