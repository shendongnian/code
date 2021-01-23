    foreach(var searchItem in myList)
    {
        Test item;
        if(myDict.TryGetValue(searchItem.Name, out item))
        {
            if(searchItem.Date > item.Date)
                item.Date = searchItem.Date;
        }
        else
            // create a copy, you don't want to change the original
            myDict.Add(searchItem.Name, new Test { Name = searchItem.Name, Date = searchItem.Date});
    }
