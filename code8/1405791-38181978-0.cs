    byte[] pngData = null;
    using(WebClient webClient = new WebClient())
    {
      pngData = webClient.DownloadData("http://www.sample.com/pic.png");
    }
    using (var ms = new MemoryStream(pngData))
    {
        Image img = Image.FromStream(ms);
        // put img in your pictureBox
    }
