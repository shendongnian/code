      List<int> list = new List<int>();
      list.Add(1);
      list.Add(2);
      list.Add(3);
      // add required "666" items
      list.AddRange(Enumerable.Repeat(666, list.Count(x => x == 2)));
      // print out all items
      foreach(item in list)
        System.Diagnostics.Debug.Write(item); 
