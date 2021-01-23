    private void GetNode(string reportsTo, int level)
    {
        // maybe have some config or value you can set for the max level you want.
        if (level >= 2) return; 
  
        SPListItemCollection itemCol = GetListItems(listName, reportsTo);
        foreach (SPListItem item in itemCol)
        {
            //create a new row
            sAllNewRows += createNewRow(item);
            //Recursion
            GetNode(item["Name"].ToString(). ++level);
        }
    }
