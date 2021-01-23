    List<int> matchedIDs = new List<int>();
    foreach(var item in tupleList)
    {
       if(matchedIDs.Contains(item.ID))
       {
           //do something
       } else {
           matchedIDs.Add(item.ID);
           //do something else
       }
    } 
