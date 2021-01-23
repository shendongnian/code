    public string ValueAsCsv
    {
      get
      {
        return string.Join(",", value.Select(x => x.name));
      }
    }
