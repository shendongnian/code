    public static class MethodExtensions{
          
          public static IEnumerable<Model_Table> Query(this IQueryable<TEntity> source, string data){
                 return (from x in source
                 where x.Login_Status == data
                 orderby x.SUB_DATE descending
                 select new Model_Table()
                {
                    Id = x.ID,
                    Name = x.NAME,
                    Code = x.Code,
                    DateSubmitted = x.SUB_DATE
                }).ToList<Model_Table>();
          }
    }
