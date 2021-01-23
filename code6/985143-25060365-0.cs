    [XMLIgnore]
    public object Value;
    [XMLText]
    public string ValueString
    {
      get{ return this.Value.ToString(); }
    }
  
