    public static IQueryable<TEntity> FromSql<TEntity>(
            [NotNull] this IQueryable<TEntity> source,
            [NotNull] [NotParameterized] string sql,
            [NotNull] params object[] parameters)
            where TEntity : class
