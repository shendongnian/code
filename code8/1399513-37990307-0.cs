     ListItemCollection items;
     List<ListItemCollection> allItems = new List<ListItemCollection>();
    
     foreach (PublishedProject proj in projects)
     {
            items = list.GetItems(proj);
            allItems.Add(items);
    
     }
     spClientCtx.Load(allItems);
     spClientCtx.ExecuteQuery();
