    private RootObject FetchMountain(string urlmountain)
    {
        // Create an HTTP web request using the URL:
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(urlmountain));
        request.ContentType = "application/json";
        request.Method = "GET";
        using (WebResponse response = request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader streamReader = new StreamReader(stream))
        {
            JsonSerializer serializer = new JsonSerializer();
            RootObject[] mountains = (RootObject[])serializer.Deserialize(streamReader, typeof(RootObject[]));
            return (mountains.Count > 0) ? mountains[0] : null;
        }
    }
