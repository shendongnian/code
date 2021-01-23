    //uploadPath = "/documentname.docx";
    //filename = "documentname.docx";
    var request = service.OneDriveClient.Drive.Root.ItemWithPath(uploadPath).CreateSession(new ChunkedUploadSessionDescriptor() { Name = Uri.EscapeUriString(System.IO.Path.GetFileName(filename)) }).Request();
    var session = request.PostAsync().Result;
            
    using (var stream = new System.IO.FileStream(filename, System.IO.FileMode.Open))
            {
                if (stream != null)
                {
                    Microsoft.OneDrive.Sdk.Helpers.ChunkedUploadProvider chunk = new Microsoft.OneDrive.Sdk.Helpers.ChunkedUploadProvider(
                session, client, stream);
                    var item = chunk.UploadAsync().Result; 
                }
            }
