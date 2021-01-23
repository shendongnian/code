    public static Type GetEnumType(string name)
    {
      return 
       (from assembly in AppDomain.CurrentDomain.GetAssemblies()
        let type = assembly.GetType(name)
        where type != null
           && type.IsEnum
        select type).FirstOrDefault();
    }
