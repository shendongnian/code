    #if !PCL
      public ICollection<User> Users{get;set;}
    #endif
    #if PCL
      public List<User> Users{get;set;}
    #endif
