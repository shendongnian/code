      Dictionary<SomeAction, int> map = new Dictionary<SomeAction, int>() {
        {SomeAction.Read, 2},
        {SomeAction.Create, 1}, // Create should be 1st
        {SomeAction.Update, 2}, // Read and Update considered interchangeable
        ...
        {SomeAction.Create, 15},
      };
    
      ...
    
      var orderedRight = list
        .OrderBy(item => map[item.Action])
        .Select(item => item.Action);
    
      boolean inCorrectOrder = list.SequenceEqual(orderedRight
       .Select(item => item.Action));
