    var wis = (WorkItemStore)Connection.ProjectCollection.GetService(typeof(WorkItemStore));
    var pj = wis.Projects.Cast<Project>().FirstOrDefault(x => x.Name == projectName);
    if (pj == null)
	    return new List<string>();
    foreach (Node area in pj.AreaRootNodes)
    {
	    resultList.Add(area.Path);
	    resultList.AddRange(from Node item in area.ChildNodes select item.Path);
    }
