    public List<TModel> LoadListOfModels<TDbModel, TModel>(
      Func<LinqToSqlDataContext, TDbModel> modelSelector,
      Func<TDbModel, bool> isDeleted,
      Func<TDbModel, TModel> modelFactory,
      bool includeDeleted = false)
    {
        using (LinqToSqlDataContext dc = new LinqToSqlDataContext())
        {
            var models = modelSelector(dc);
            IQueryable<TModel> filtered = includeDeleted
                ? models.Where(c => !isDeleted(c))
                : models;
            return filtered.Select(modelFactory).ToList();
        }
    }
