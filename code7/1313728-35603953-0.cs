    protected void Button1_Click(object sender, EventArgs e)
    {
        BlobService upload = new BlobService();
    
        System.IO.FileStream streamToUpload = new System.IO.FileStream(FileUpload.PostedFile.FileName, 
                   System.IO.FileMode.Open, System.IO.FileAccess.Read)
        upload.UploadBlob(streamToUpload );
    }
