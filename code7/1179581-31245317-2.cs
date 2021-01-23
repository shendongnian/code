    Public String NameAndRole
    {
      get
       { return name + " | "+ String.Join(",", UserRole.ToArray()) }
    }
