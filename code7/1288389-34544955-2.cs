    [WebMethod]
    public string Ping()
    {
        Context.Request.InputStream.Seek(0, SeekOrigin.Begin);
        using (var inputStream = Context.Request.InputStream)
        using (var reader = new StreamReader(inputStream))
        {
            string body = reader.ReadToEnd();
            // TODO: Worth checking the request headers before attempting JSON deserialization
            // For example the Content-Type header
            var model = JsonConvert.DeserializeObject<MyModel>(body);
            if (string.IsNullOrEmpty(model.AdditionalInfo))
            {
                return "Process msg with old version";
            }
            return "Process msg with new version"; ;
        }
    }
