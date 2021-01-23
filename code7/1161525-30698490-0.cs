    using (WebClient webClient = new WebClient())
    {
      byte[] data = webClient.DownloadData(@"http://192.0.2.82:6180/audio.wav");
      using (MemoryStream mem = new MemoryStream())
      {
        mem.Write(data, 0 , data.Length);
        recEngine.SetInputToWaveStream(mem);
      }
    }
