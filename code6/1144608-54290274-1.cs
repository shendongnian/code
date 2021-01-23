public override IQueryable<TEntity> Find<TEntity>()
{
   var query = GetRepository<TEntity>().Find();
   if (!ShouldFetchSoftDeleted)
   {
     return query; // interceptor handles soft delete
   }
   query = GetRepository<TEntity>().Find();
   return Where<IDeletedInfo, TEntity>(query, x => x.IsDeleted == false || x.IsDeleted);
}
