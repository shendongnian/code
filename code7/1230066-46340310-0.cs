     public class blobservice
        {
            public CloudBlobContainer GetCloudBlobContainer()
            {
                string connString = "DefaultEndpointsProtocol=https;AccountName="";AccountKey=E"";";
                string destContainer = "mysample";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(destContainer);
                
                if (blobContainer.CreateIfNotExists())
                {
                    blobContainer.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });
        
                }
                return blobContainer;
            }
        }
    3..aspx.cs
    
     blobservice _blobServices = new blobservice();
        protected void Page_Load(object sender, EventArgs e)
        {
            blobservice _blobServices = new blobservice();
            Upload();
        }
        
        public void Upload()
        {
            CloudBlobContainer blobContainer = _blobServices.GetCloudBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference("Sampleblob.jpg");
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(Server.MapPath("~/Images/active.png"));
            using (Stream ms = new MemoryStream(bytes))
            {
                blob.UploadFromStream(ms);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string Name = "https://bikeimages.blob.core.windows.net/mysample/Sampleblob.jpg";
            Uri uri = new Uri(Name);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);
            blobservice _blobServices = new blobservice();
            CloudBlobContainer blobContainer = _blobServices.GetCloudBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(filename);
            blob.Delete();
        }
