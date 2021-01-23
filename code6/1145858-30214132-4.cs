    private class DescendingComparer : IComparer<int>
    {
      int IComparer<int>.Compare(int a, int b)
      {              
        return b - a;
      }
    }
    // ....
    ClassItems = new SortedDictionary<int, object>(x.SelectMany(y => y. ItemsPrice)
                                                    .GroupBy(y => y. Price.item.Name)
                                                    .ToDictionary(y => y.Key, y => y.Sum(z => z.TotalPrice())),
                                                   new DescendingComparer());
