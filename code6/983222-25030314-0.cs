    var dc = new SiteDataContext(new Uri("http://contoso.intranet.com/_vti_bin/ListData.svc/"));
    dc.Credentials = System.Net.CredentialCache.DefaultCredentials;
    foreach (var task in dc.Tasks)
    {
       string taskTitle = task.Title;
       var assignedTo = dc.UserInformationList.Where(i => i.Id == task.AssignedToId).FirstOrDefault();
       var assignedToName = assignedTo.Name;
    }
