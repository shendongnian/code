    public void UploadFile(string fileName, string url)
    {
        var webClient = new WebClient();
        byte[] rawResponse = webClient.UploadFile(url, filename);
        string response = System.Text.Encoding.ASCII.GetString(rawResponse);
        Console.WriteLine(response);
    }
