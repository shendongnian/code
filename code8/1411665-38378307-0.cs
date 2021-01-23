    public void DownloadAndUpdatePicture()
    {
      string url = "http://IPofIPCamera/now.jpg";
      WebClient webClient = new WebClient();
      CredentialCache myCache = new CredentialCache();
      myCache.Add(new Uri(url), "Basic", new NetworkCredential("SomeUser", "SomePass"));
      webClient.Credentials = myCache;
      MemoryStream imgStream = new MemoryStream(webClient.DownloadData(url));
      pictureBox1.Image = new System.Drawing.Bitmap(imgStream);
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
      this.DownloadAndUpdatePicture();
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
      this.DownloadAndUpdatePicture();
    }
