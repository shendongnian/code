        var outputStream = ((HttpListenerContext)Request.GetOwinEnvironment()["System.Net.HttpListenerContext"]).Response.OutputStream;
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new PushStreamContent(
                async (stream, httpContent, arg3) =>
                {
                    await outputStream.WriteAsync(content, 0, content.Length);
                    stream.Close();
                })
            {
                Headers =
                {
                    ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileNameStar = fileName,
                        Size = content.Length,
                    },
                    ContentType = MediaTypeHeaderValue.Parse(mediaType),
                    ContentLength = content.Length,
                }
            }
        };
