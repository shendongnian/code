    using (WebClient client = new WebClient())
    {
        NameValueCollection postData = new NameValueCollection()
        {
            { "newQuery", query },
            { "P1", username }
        };
    }
