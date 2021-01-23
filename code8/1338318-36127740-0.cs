    public Object[][] bloop(string[] bstr) {
      if (null == bstr)
        throw new ArgumentNullException("bstr");
      int v;
      return bstr
        .GroupBy(x => int.TryParse(x, out v))
        .OrderBy(chunk => chunk.Key)
        .Select(chunk => chunk.ToArray())
        .ToArray();
    }
