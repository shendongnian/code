    using (var webClient = new WebClient())
    {
      using (var stream = webClient.OpenRead("http://1.2.3.4/image.png"))
      {
        pictureBox1.Image = new Bitmap(stream);
      }
    }
