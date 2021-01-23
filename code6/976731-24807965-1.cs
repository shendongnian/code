    public ActionResult ListFiles()
    {
   
     var fileList = new List<FileViewModel>();
     //.. code to connect to the azure account and container
     foreach (IListBlobItem item in container.ListBlobs(null, false))
    {
		     if (item.GetType() == typeof(CloudBlockBlob))
		    {
		        CloudBlockBlob blob = (CloudBlockBlob)item;
		       fileList.Add(new FileViewModel
		        {
 					FileName = blob.Properties.Name;
 					AzureUrl = blob.Uri;
		       	})
		    }
      }
     return View(fileList)
    }
