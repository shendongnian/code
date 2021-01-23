    string xmlText = "";
    // Read the file as a string
    using (WebClient client = new WebClient())
    {
        client.Credentials = new NetworkCredential("username", "password");
        xmlText = client.DownloadString(url);
    }
