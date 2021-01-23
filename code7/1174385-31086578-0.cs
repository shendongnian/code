    try
    {
        WebClient client = new WebClient();
        string myFile = @"D:\test_file.txt";
        client.Credentials = CredentialCache.DefaultCredentials;
        client.UploadFile(@"http://localhost/uploads/upload.php", "POST", myFile);
        client.Dispose();
    }
    catch (Exception err)
    {
        MessageBox.Show(err.Message);
    }
