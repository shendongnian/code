    public async Task UploadFileByFtpAsync()
    {
       try
       {
           WebClient webClient = new WebClient();
           OpenFileDialog fd = new OpenFileDialog();
           fd.ShowDialog();
           MessageBox.Show(fd.FileName);
           Task<byte[]> response = await webClient.UploadFileTaskAsync(new Uri("ftp://" + "username" + ":" +"pass" +"@" + "address/" + "name.ext"), fd.FileName);
           // You might want to validate the response status code is valid here
        }
        catch (Exception ex)
        { 
            MessageBox.Show(ex.Message);
            // Do useful exception handling here
        }
    }
