      private void Download_Click(object sender, RoutedEventArgs e)
       {
          using (WebClient wc = new WebClient())
          {
             wc.DownloadProgressChanged += wc_DownloadProgressChanged;
             wc.DownloadFileAsync(new System.Uri("http://url"),
              "Result location");
          }
       }
