    public static IQueryable<Profile> Filter(
      this IQueryable<Profile> source, string name, Guid uuid)
    {
      // .<name>UUID
      var property = typeof(Profile).GetProperty(name + "UUID");
      // p
      var parExp = Expression.Parameter(typeof(Profile));
      // p.<name>UUID
      var methodExp = Expression.Property(parExp, property);     
      // uuid
      var constExp = Expression.Constant(uuid, typeof(Guid));    
      // p.<name>UUID == uuid
      var binExp = Expression.Equal(methodExp, constExp);                  
      // p => p.<name>UUID == uuid
      var lambda = Expression.Lambda<Func<Profile, bool>>(binExp, parExp);
      // source.Where(p => p.<name>UUID == uuid)
      return source.Where(lambda);
    }
