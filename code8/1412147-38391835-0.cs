      // Simplest, not thread safe
      private static Random r = new Random();
      ...
      private static List<int> MakeMyList(int count, int topBorder) {
        // Raw list with outliners
        List<int> list = Enumerable
          .Range(0, count)
          .Select(i => r.Next(1, topBorder))
          .ToList();
        //TODO: compute the tolerable interval here
        double leftBorder = ...
        double rightBorder = ...
        // outliners dropping
        list.RemoveAll(item => item < leftBorder || item > rightBorder);
        return list;       
      }
...
      // Assigning to the UI
      foreach(item in MakeMyList(30, 60))
        lst1.Items.Add(item.ToString()); 
      foreach(item in MakeMyList(30, 1000))
        lst2.Items.Add(item.ToString());    
