    public void RegisterAssemblies(Assembly[] assemblies)
    {
      foreach(var assembly in assemblies)
      {
        foreach(var type in assembly.GetTypes())
        {
          Register(type);
        }
      }
    }
