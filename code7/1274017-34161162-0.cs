    using (ClientContext conext = new ClientContext(site.url))
    {
        List projectFiles = projects.Web.Lists.GetByTitle("Project Files");
        context.Load(projectFiles.RootFolder, w => w.ServerRelativeUrl);                       
        context.ExecuteQuery();
        FileStream documentStream = System.IO.File.OpenRead(filePath);
        byte[] info = new byte[documentStream.Length];
        documentStream.Read(info, 0, (int)documentStream.Length);
        string fileURL = projectFiles.RootFolder.ServerRelativeUrl + "/Folder/FileName.ext";
        FileCreationInformation fileCreationInformation = new FileCreationInformation();
        fileCreationInformation.Overwrite = true;
        fileCreationInformation.Content = info;
        fileCreationInformation.Url = fileURL;
        Microsoft.SharePoint.Client.File uploadFile = projectFiles.RootFolder.Files.Add(fileCreationInformation);
        context.Load(uploadFile, w => w.MajorVersion, w => w.MinorVersion);
        context.ExecuteQuery();
    }
