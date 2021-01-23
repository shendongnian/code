    private class DescendingComparer : IComparer<string>
    {
      int IComparer<string>.Compare(string a, string b)
      {              
        return StringComparer.InvariantCulture.Compare(b, a);
      }
    }
    // ....
    ClassItems = new SortedDictionary<string, float>(x.SelectMany(y => y. ItemsPrice)
                                                    .GroupBy(y => y. Price.item.Name)
                                                    .ToDictionary(y => y.Key, y => y.Sum(z => z.TotalPrice())),
                                                   new DescendingComparer());
