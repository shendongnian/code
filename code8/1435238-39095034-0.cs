    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        Stream stream = response.GetResponseStream());
        using (StreamReader reader = new StreamReader(stream))
        {
            responce = reader.ReadToEnd();
        }
    }
