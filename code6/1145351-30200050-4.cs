      private IOrderedEnumerable<string> GetResults() {
         SortedList<int, string> list = new SortedList<int, string>();
         list.Add(40, "Mehrzad");
         list.Add(20, "Chehraz");
         return list.Values.OrderBy(key => 0);         
      }
