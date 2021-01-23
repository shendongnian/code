      File resultFile = null;
      FilesResource.ListRequest listRequest = _service.Files.List();
        /* Specify camelCase format to specify fields. You can also check in debug mode the files properties before requesting which will be null. All properties will be capitalized so make th efirst letter as small(camel case standard)*/
        
      listRequest.Fields = "files(id, webViewLink, size)";                
      var files = listRequest.Execute().Files;
                                       
     
            if (files != null && files.Count > 0)
            {
                    foreach (var file in files)
                    {
                          if (file.Id == _fileId)
                          {
                               Console.WriteLine("{0}, {1}, {2}", file.Name, file.Id, file.WebViewLink, file.Size);
                               resultFile = file;
                          }
                     }
             }
