    private void UploadFilesToRemoteUrl(string Link_To_ASP, string files)
    {
         WebClient wc = new WebClient();
         byte[] responseArray = wc.UploadFile(url,"POST", files);
         Console.WriteLine("\nAttachmentID:\n{0}",Encoding.ASCII.GetString(responseArray));
    }
