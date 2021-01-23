    private static int GetItemId(SP.ClientContext context, string columnName, string displayName, string listName, SP.ListItem thisItem)
    {
        thisItem.Update();
    
        //this rest of the code is the same
        ...
    }
