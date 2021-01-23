    Google.Apis.Drive.v2.Data.File bigFolder = new Google.Apis.Drive.v2.Data.File
    {
        Title = "Folder Title",
        Description = "The folder",
        MimeType = "application/vnd.google-apps.folder",
        Parents = new List<ParentReference>() {new ParentReference() {Id = biggerFolder.Id}}  
    };
    bigFolder = service.Files.Insert(bigFolder).Execute();
    Google.Apis.Drive.v2.Data.File[] underFolder = new Google.Apis.Drive.v2.Data.File[4];
    for (int i = 0; i < 4; i++)
    {
        underFolder[i] = new Google.Apis.Drive.v2.Data.File
        {
            Title = nom[i],
            Description = "The other folder",
            MimeType = "application/vnd.google-apps.folder",
            Parents = new List<ParentReference>() {new ParentReference() {Id = bigFolder.Id}}
        };
        underFolder[i] = service.Files.Insert(underFolder[i]).Execute();
    }
