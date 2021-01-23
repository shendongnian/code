    var account = new CloudStorageAccount(new StorageCredentials("accountName", "keyvalue"), true);
    CloudBlobClient blobClient = account.CreateCloudBlobClient();
    CloudBlobContainer container =blobClient.GetContainerReference("containername");
    CloudBlockBlob blobread = container.GetBlockBlobReference(Session["UploadPDFFile"].ToString());
    MemoryStream msRead = new MemoryStream();                                
    using (msRead)
    {
      blobread.DownloadToStream(msRead);
      msRead.Position = 0;
    
      objMailMessgae.Attachments.Add(new System.Net.Mail.Attachment(msRead,    Session["UploadPDFFile"].ToString(), "pdf/application"));
    
       try
       {
         objSmtpClient.Send(objMailMessgae);
       }
       catch (Exception ex) {
                string s = ex.Message;
            }
        }
