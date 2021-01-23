public static List<T> ToList<T>(this IQueryable<T> query)
{
  using (TransactionScope ts = CreateNoLockTransaction())
  {
   return query.AsEnumerable().ToList();
  }
}
  
