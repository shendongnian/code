    var itemsToRemove = new List<ListItem>();
    foreach (ListItem item in chkEnvironment.Items)
    {
        if (item.Value == "NULL")
        {
            itemsToRemove.Add(item);
        }
    }
    foreach(var item in  itemsToRemove)                 
        chkEnvironment.Items.Remove(item);
