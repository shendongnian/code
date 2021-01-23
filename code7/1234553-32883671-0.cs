    string fileUrl = "http://enternal.website/link/to/file.xlsx";
    string tempUrl = "\\\\localserver\\directory\\file.xlsx";
    using (WebClient client = new WebClient())
    {
         client.Credentials = System.Net.CredentialCache.DefaultCredentials;
         client.DownloadFile(fileUrl, tempUrl);
    }
