    public HttpResponseMessage GetFile()
    {
        FileStream file = XLGeneration.XLGeneration.getXLFileExigence();
        using(var sr = new StreamReader(file))
        {
            content = sr.ReadToEnd();
            return new HttpResponseMessage
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };
        }
    }
