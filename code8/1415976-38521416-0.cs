    private void PendChangesAndCheckIn(string pathToWorkspace)
    {
        //Get Version Control Server object
        VersionControlServer vs = collection.GetService(typeof
    (VersionControlServer)) as VersionControlServer;
        Workspace ws = vs.TryGetWorkspace(pathToWorkspace);
    
        //Do Delete and Copy Actions to local path
    
        //Create a item spec from the server Path
        PendingChange[] candidateChanges = null;
        string serverPath = ws.GetServerItemForLocalItem(pathToWorkspace);
        List<ItemSpec> its = new List<ItemSpec>();
        its.Add(new ItemSpec(serverPath, RecursionType.Full));
    
        //get all candidate changes and promote them to included changes
        ws.GetPendingChangesWithCandidates(its.ToArray(), true, 
    out candidateChanges);
    foreach (var change in candidateChanges)
        {
            if (change.IsAdd)
            {
                ws.PendAdd(change.LocalItem);
            }
            else if (change.IsDelete)
            {
                ws.PendDelete(change.LocalItem);
            }
        }
    
        //Check In all pending changes
        ws.CheckIn(ws.GetPendingChanges(), "This is a comment");
    }
