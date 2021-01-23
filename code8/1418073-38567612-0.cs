    var bList = new List<Budget.budget_data>();
    // ...
    var z = ...;
    
    for (var x = 0; x < bList.Count; ++x)
    {
      if (x == z)
        continue;
     
      if (bList[z].Range == bList[x].Range)
      {
        //need to perform action
      }
    }
