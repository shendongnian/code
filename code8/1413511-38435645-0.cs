    private static IEnumerable<double> sortDoppelganger(List<double> doubles)
    {
      var newList = new List<double>();
      foreach (var t in doubles)
      {
        newList.Add(!newList.Contains(t) ? t : 0.0);
      }
      return newList;
    }
