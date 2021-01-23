    public List<Google.Apis.Drive.v2.Data.File> ResFromFolder(DriveService service, string folderId)
    {
        var request = service.Children.List(folderId);
        request.MaxResults = 1000;
        List<Google.Apis.Drive.v2.Data.File> TList = new List<Google.Apis.Drive.v2.Data.File>();
        do
        {
            var children = request.Execute();
            foreach (ChildReference child in children.Items)
            {
                TList.Add(service.Files.Get(child.Id).Execute());
            }
            request.PageToken = children.NextPageToken;
        } while (!String.IsNullOrEmpty(request.PageToken));
        return TList;
    }
