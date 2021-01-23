    List<int> matchedIDs = new List<string>();
    foreach(var item in tupleList)
    {
      if(matchedIDs.contains(item.ID))
      {
       // do something
      }
      else
      {
       // do something else
        matchedIDs.Add(item.ID);
      }
    } 
