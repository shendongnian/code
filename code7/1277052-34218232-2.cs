    foreach(var group in tupleList.GroupBy(x => x.ID))
    {
      var id = group.Key;
      var firstItemWithThisId = group.First();
      // iterate the items in the group
      foreach (var item in group)
      {
        // do something with the item
      }
      // do something 
    } 
