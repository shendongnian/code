     private string GetJsonContents(System.Web.HttpRequestBase Request)
        {
            string JsonContents = string.Empty;
            try
            {
                using (Stream receiveStream = Request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream))
                    {
                        receiveStream.Seek(0, System.IO.SeekOrigin.Begin);
                        JsonContents = readStream.ReadToEnd();
                    }
                }
            }
            catch
            {
            }
            return JsonContents;
        }
