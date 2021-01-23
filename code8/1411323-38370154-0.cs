      // A little bit of Linq: ToDictionary 
      var dict = list_2.ToDictionary(item => item.ID, item => item);
      ...
      foreach (item in list_1) {
        foo master;
        if (dict.TryGetValue(item.ID, out master)) {
          item.name = master.name; 
          item.color = master.color;
        }
      }
         
