    try
    {
        using (var client = new WebClient())
        using (var stream = client.OpenRead(url83))
        {
            XmlTextReader reader1 = new XmlTextReader(stream);
            reader1.WhitespaceHandling = WhitespaceHandling.None;
            //Do something
        }
    }
    catch (WebException ex)
    {
         // occurs when any error occur while reading from network stream
    }
