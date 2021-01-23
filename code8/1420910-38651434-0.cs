    StringBuilder itemList = new StringBuilder();
    
    for (int i = 0; i < TestList.Count; i++)
    {
        itemList.Append(string.Format("\"{0}\" || ", TestList[i].Code));
    }
