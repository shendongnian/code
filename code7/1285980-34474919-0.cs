    static string yourSuperSecretDirectory = @"C:\ApplicationName\Uploads";
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if(FileUploadControl.HasFile)
        {
            string filename = Path.Combine(yourSuperSecretDirectory, FileUploadControl.FileName);
            FileUploadControl.SaveAs(filename); //actually save/upload the file
            string temp = ftp + ftpFolder + filename
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(loginName, password);
                    client.UploadFile(temp, "STOR", FileUploadControl.FileName); // ???
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
