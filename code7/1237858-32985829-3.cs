    public Decimal Total
    {
      get
      {
        return Items.Sum(x => x.Total);
      }
    }
