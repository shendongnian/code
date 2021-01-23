    foreach(var searchItem in myList)
    {
        Test item;
        if(myDict.TryGetValue(searchItem.Name, out item))
        {
            if(searchItem.Date > item.Date)
            {
                // swap the dates to keep the original objects intact (but this will change the order in the list.)
                var temp = item.Date;
                item.Date = searchItem.Date;
                searchItem.Date = temp;
            }
        }
        else
            // create a copy, you don't want to change the original
            myDict.Add(
                searchItem.Name, 
                searchItem);
    }
