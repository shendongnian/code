    public override bool IsValid(object value)
    {
       try
       {
          value = value.ToString();
          return base.IsValid(value);
       }
       catch { }
       return base.IsValid(value);
    }
