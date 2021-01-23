    //Async because this is asynchronous process and would read stream data in a buffer. 
    //If you don't make this async, you would be only reading a few KBs (buffer size) 
    //and you wont be able to know why it is not working
    public async Task<HttpResponseMessage> Post()
    {
    if (!request.Content.IsMimeMultipartContent()) return null;
            Dictionary<string, object> extractedMediaContents = new Dictionary<string, object>();
            //Here I am going with assumption that I am sending data in two parts, 
            //JSON object, which will come to me as string and a file. You need to customize this in the way you want it to.           
            extractedMediaContents.Add(BASE64_FILE_CONTENTS, null);
            extractedMediaContents.Add(SERIALIZED_JSON_CONTENTS, null);
            request.Content.ReadAsMultipartAsync()
                    .ContinueWith(multiPart =>
                    {
                        if (multiPart.IsFaulted || multiPart.IsCanceled)
                        {
                            Request.CreateErrorResponse(HttpStatusCode.InternalServerError, multiPart.Exception);
                        }
                        foreach (var part in multiPart.Result.Contents)
                        {
                            using (var stream = part.ReadAsStreamAsync())
                            {
                                stream.Wait();
                                Stream requestStream = stream.Result;
                                using (var memoryStream = new MemoryStream())
                                {
                                    requestStream.CopyTo(memoryStream);
                                    //filename attribute is identifier for file vs other contents.
                                    if (part.Headers.ToString().IndexOf("filename") > -1)
                                    {                                        
                                        extractedMediaContents[BASE64_FILE_CONTENTS] = memoryStream.ToArray();
                                    }
                                    else
                                    {
                                        string jsonString = System.Text.Encoding.ASCII.GetString(memoryStream.ToArray());
                                       //If you need just string, this is enough, otherwise you need to de-serialize based on the content type. 
                                       //Each content is identified by name in content headers.
                                       extractedMediaContents[SERIALIZED_JSON_CONTENTS] = jsonString;
                                    }
                                }
                            }
                        }
                    }).Wait();
            //extractedMediaContents; This now has the contents of Request in-memory.
    }
