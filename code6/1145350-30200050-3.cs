    private IOrderedEnumerable<string> GetResults() {
         SortedList<int, string> list = new SortedList<int, string>();
         list.Add(20, "Mehrzad");
         list.Add(10, "Chehraz");
         return new OrderedEnumerableWithoutKey<int, string>(list.OrderBy(item => item.Key));    }
    ..
    ..
    // Consumer part:
    IOrderedEnumerable<string> enumerable = GetResults();
    foreach (var item in enumerable) {
          System.Diagnostics.Debug.WriteLine(item);
    }
    // Outputs:
    // Cherhaz
    // Mehrzad
