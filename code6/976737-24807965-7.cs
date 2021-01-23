    public ActionResult ListFiles()
    {
   
     var fileList = new List<FileViewModel>();
     //.. code to connect to the azure account and container
     foreach (IListBlobItem item in container.ListBlobs(null, false))
    {
		     if (item.GetType() == typeof(CloudBlockBlob))
		    {
		        CloudBlockBlob blob = (CloudBlockBlob)item;
            //In case blob container's ACL is private, the blob can't be accessed via simple URL. For that we need to
            //create a Shared Access Signature (SAS) token which gives time/permission bound access to private resources.
            var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),//Asssuming user stays on the page for an hour.
            });
            var blobUrl = blob.Uri.AbsoluteUri + sasToken;//This will ensure that user will be able to access the blob for one hour.
		       fileList.Add(new FileViewModel
		        {
 					FileName = blob.Properties.Name;
 					AzureUrl = blobUrl;
		       	})
		    }
      }
     return View(fileList)
    }
