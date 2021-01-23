    ClientContext clientContext = new ClientContext("http://SpSiteUrl");
    clientContext.ExecuteQuery();
    FileInformation fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, "thisFile");
   
    System.IO.Stream stream = fileInfo.Stream;
    new System.IO.StreamReader(stream);
    while((line = file.ReadLine()) != null)
    {
       System.Console.WriteLine (line);  
    }
