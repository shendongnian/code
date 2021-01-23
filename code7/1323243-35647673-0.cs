    public bool HasValue
    {
      get
      {
        return this.GetValue(false, false) != null;
      }
    }
    public string GetValue(bool allowStandardValue, bool allowDefaultValue)
    {
      ...
    }
