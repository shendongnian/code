        protected void Application_BeginRequest()
        {
            if (!Request.HttpMethod.Equals("post", StringComparison.InvariantCultureIgnoreCase)) {
                return; 
            }
            string documentContents;
            using (var receiveStream = Request.InputStream)
            {
                using (var readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    documentContents = readStream.ReadToEnd();
                }
            }
            try
            {
                var json = JObject.Parse(documentContents);
                File.WriteAllLines(@"C:\test\keys.txt", new[] { documentContents, "\r\n", json.ToString() });
            }
            catch (Exception)
            {
                 // do something
            }
        }
