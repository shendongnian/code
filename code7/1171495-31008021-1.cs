    private static IQueryable<T> Filter<T>(IQueryable<T> source, bool makeA21Match)
    {
      if(makeA21Match)
      {
        var getA = typeof(T).GetProperty("A"); // .A
        var getD = typeof(T).GetProperty("D"); // .D
        var getAA21 = typeof(SezioneA).GetProperty("A21"); // a.A21 for some A.
        var getDA21 = typeof(SezioneD).GetProperty("A21"); // d.A21 for some D.
        var parExp = Expression.Parameter(typeof(T)); // sj.
        var getAExp = Expression.Property(parExp, getA); // sj.A
        var getDExp = Expression.Property(parExp, getD); // sj.D
        var getAA21Exp = Expression.Property(getAExp, getAA21); // sj.A.A21
        var getDA21Exp = Expression.Property(getDExp, getDA21); // sj.D.A21
        var eqExp = Expression.Equal(getAA21Exp, getDA21Exp); // sj.A.A21 == sj.D.A21
        var λExp = Expression.Lambda<Func<T, bool>>(eqExp, parExp); // sj => sj.A.A21 == sj.D.A21
        source = source.Where(λExp);
      }
      return source;
    }
