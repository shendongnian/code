    private static void SortDesc(List<Items> items)
    {
      var tempList = items.OrderByDescending(x => x.Neto).ToList();
      items.Clear();
      items.AddRange(tempList);
    }
