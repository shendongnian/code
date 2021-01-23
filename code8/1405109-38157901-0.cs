    Console.WriteLine(strURL);
    using (WebClient myWebClient = new WebClient())
    {
      myWebClient.Headers["Content-Type"] = "image/png";
      if (File.Exists("test_image.jpeg"))
      {
        File.Delete("test_image.jpeg");
      }
      myWebClient.DownloadFile(new Uri(strURL), "test_image.jpeg");
    }
