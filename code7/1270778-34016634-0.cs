    WebClient _webClient = new WebClient
        {
            UseDefaultCredentials = true,
            Encoding = System.Text.Encoding.UTF8,
            Headers = new WebHeaderCollection
            {
                "user-agent: Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"
            }
        };
