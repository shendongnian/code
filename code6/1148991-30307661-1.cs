    var tempList=new List<int>();//assuming int values in list    
    foreach (var item in itemsList)
    {
        if(randomValues.Contains(item.itemID))
        {
            tempList.Add(item); //add item to temp list
            //some code
        }
    }
    return tempList;
