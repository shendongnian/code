      byte[] data;
      using (WebClient wc = new WebClient()) {
        wc.UseDefaultCredentials = true; // if you have a proxy etc.
        data = wc.DownloadData(myUrl); 
      }
