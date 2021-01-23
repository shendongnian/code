    private IQueryable<Products> ApplyFilter(
              IQueryable<Products> qry,
              Expression<Func<Products,String>> field,
              String likeFilter)
    {
      var func = field.Compile();
      return qry.Where(p => func(p).Contains(likeFilter));
    }
