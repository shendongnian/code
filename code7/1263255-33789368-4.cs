    using (var clientContext = new ClientContext(url))  {
        Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, "thisFile");
        using (var fileStream = System.IO.File.Create(getItem))
         {                  
            fileInfo.Stream.CopyTo(fileStream);
         }
    }
