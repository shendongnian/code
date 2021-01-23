    public void DownloadFileWithFtp() {
      FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://XYZ.bplaced.net/Testumgebung/Texte/" + comboBox_DataPool.SelectedValue);
      request.Credentials = new NetworkCredential("BN", "PW");
      request.Method = WebRequestMethods.Ftp.DownloadFile;
    
      using(FtpWebResponse response = (FtpWebResponse)request.GetResponse()) {
        using(Stream responseStream = response.GetResponseStream()) {
          using(StreamReader streamReader = new StreamReader(responseStream)) {
            string content = streamReader.ReadToEnd();
            MessageBox.Show(content);
            textBox.Text = content;
          }
        }
        MessageBox.Show(response.StatusDescription);
      }
    }
