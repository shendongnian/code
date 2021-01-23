    SPQuery query = new SPQuery();
    SPFolder folder = get the folder object by folder path
    query.Folder = folder;
    query.ViewXml = "<View Scope=\"RecursiveAll\"><Query>your query goes here</Query></View>";
    SPListItemCollection items = yourLibrary.GetItems(query);
    
    foreach (SPListItem item in items)
    {
        // Do something
    }
