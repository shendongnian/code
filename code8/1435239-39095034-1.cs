    Stream stream = null;
    try
    {
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            stream = response.GetResponseStream());
            using (StreamReader reader = new StreamReader(stream))
            {
                responce = reader.ReadToEnd();
            }
        }
    }
    finally
    {
        // check if stream is not null (although it should be), and dispose of it
        if (stream != null)
            stream.Dispose();
    }
