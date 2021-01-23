    ClientContext clientContext = new ClientContext("http://SpSiteUrl");
    clientContext.ExecuteQuery();
    FileInformation fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, "thisFile");
   
    System.IO.Stream stream = fileInfo.Stream;
    
    using (StreamReader r = new StreamReader(stream))
         string line;
         while((line = file.ReadLine()) != null)
         {
             System.Console.WriteLine (line);  
         }
    }
