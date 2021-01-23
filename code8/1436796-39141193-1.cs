    SPQuery query = new SPQuery();
    SPFolder folder = get the folder object by folder path
    query.Folder = folder;
    query.ViewXml = "<View Scope=\"RecursiveAll\"><Query>your query goes here</Query></View>";
    SPListItemCollection items = yourLibrary.GetItems(query);
    Dictionary<string, List<SPListItem>> folderItems = new Dictionary<string, SPListItem[]>();
    
    foreach (SPListItem item in items)
    {
        // If items are files
        SPFile file = item.Web.GetFile(item.Url);
        string folderName = file.ParentFolder.Name;
        if (!folderItems.ContainsKey(folderName))
        {
            folderItems[folderName] = new List<SPListItem>();
        }
        folderItems[folderName].Add(item);
    }
