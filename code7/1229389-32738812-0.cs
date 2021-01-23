    var service = new DriveService(new BaseClientService.Initializer() {HttpClientInitializer = credential,
                                                                                ApplicationName = "Drive API Sample",});
    // Dummy request example:
    FilesResource.ListRequest list = service.Files.List();
    list.MaxResults = 1;
    list.Q = "title=dummysearch";
    FileList dummyFeed = list.Execute();
    // End of Dummy request
