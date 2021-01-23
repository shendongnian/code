    versionControlServer = ServiceProvider.GetService<ITeamFoundationContextManager>().TeamProjectCollection.GetService<VersionControlServer>();
    var selectedItems = new[] {1, 2};
    var dropData = new WorkItemDropData(versionControlServer.ServerGuid, selectedItems);
    var dataObject = new DataObject("Microsoft.TeamFoundation.WorkItemId", dropData);
    DragDrop.DoDragDrop(listView, dataObject, DragDropEffects.Move);
