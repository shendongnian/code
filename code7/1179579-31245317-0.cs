    Public String NameAndRole
    {
      get
       { return name + " | "+ String.Join(",", role.ToArray()) }
    }
