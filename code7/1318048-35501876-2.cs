    private static UnityContainer container = new UnityContainer();
    
    static void RegisterGenerator<T, TG>() where TG : IQueryGenerator<T>
    {
      var assembly = typeof(T).Assembly;
      // walk trough all interfaces in assembly, if the interface inherits from
      // typeof(T), add that particular IQueryGenerator<> to container as well
      foreach (var type in assembly.GetTypes())
      {
        if (typeof(T).IsAssignableFrom(type) && type.IsInterface)
        {
          var generatorType = typeof(IQueryGenerator<>).MakeGenericType(type);
          container.RegisterType(generatorType, typeof(TG), type.Name);
        }
      }
    }
    static IEnumerable<Func<T, bool>> GenerateQueries<T>() where T : IPerson
    {
      var queryGenerators = container.ResolveAll<IQueryGenerator<T>>().ToList();
      // Fetch queries and return them.
      var queries = new List<Func<T, bool>>();
      foreach (var queryGenerator in queryGenerators)
      {
        // Do something with queryGenerator.
        queries.AddRange(queryGenerator.GenerateQueries());
      }
      return queries;
    }
