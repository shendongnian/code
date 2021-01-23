    public TempUser
    {
      public string Name { get; set; }
    } 
    
    public UserModel:TempUser
    {
      public IEnumerable<int> Roles { get; set; }
    }
