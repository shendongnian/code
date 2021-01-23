    public static IQueryable<SomeDTO<T, U>> JoinExtensionTwoColumns<T, U, Key>(this IQueryable<T> tableA, IQueryable<U> tableB, 
        Expression<Func<T, Key>> columnA, Expression<Func<U, Key>> columnB, Expression<Func<T, Key>> columnC, Expression<Func<U, Key>> columnD)
    {
        return tableA.Join(tableB, 
            a => new { column1 = columnA.Compile()(a), column2 = columnC.Compile()(a) }, 
            b => new { column1 = columnB.Compile()(b), column2 = columnD.Compile()(b) }, 
            (a, b) => new SomeDTO<T, U> { TableA = a, TableB = b });
    }
  
