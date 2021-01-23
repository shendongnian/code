    public IQueryable<TEntity> GetByFilter(
        Tuple<String, String> byWhereValueAndColumn = null,
        string byWhereString = null,
        string byOrder = null,
        string byDir = null
        );
