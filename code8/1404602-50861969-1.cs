    // For download
    using(var client = new ExtendedWebClient(MyCertificate))
    {
        // Add anything optional like authnetication or header here.
        client.DownloadFile(MyUrl, MyFile);
    }
    // ...
    // Or for upload
    using(var client = new ExtendedWebClient(MyCertificate))
    {
        // Add anything optional like authnetication or header here.
        client.UploadFile(MyUrl, "POST", MyFile);
    }
  
