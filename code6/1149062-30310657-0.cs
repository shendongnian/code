    using (var tcpClient = tcpListener.AcceptTcpClient())
    {
        XmlDocument doc = new XmlDocument();
        using (var stream = tcpClient.GetStream())
        {
            doc.Load(stream);
        }
        // Use doc here
    }
