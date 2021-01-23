    private IOrderedEnumerable<string> GetResults() {
         SortedList<int, string> list = new SortedList<int, string>();
         list.Add(10, "Mehrzad");
         list.Add(20, "Chehraz");
         return new MyOrderedEnumerable<int, string>(list);
    }
    ..
    ..
    // Consumer part:
    IOrderedEnumerable<string> enumerable = GetResults();
    foreach (var item in enumerable) {
          System.Diagnostics.Debug.WriteLine(item);
    }
    // Outputs:
    // Mehrzad
    // Chehraz
