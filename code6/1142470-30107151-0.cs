    public override SqlString ToSqlString(ICriteria criteria
      , ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
    {
        //TODO: add default capacity
        SqlStringBuilder sqlBuilder = new SqlStringBuilder();
        SqlString[] columnNames =
            CriterionUtil.GetColumnNames(propertyName, projection
                                        , criteriaQuery, criteria, enabledFilters);
        if (columnNames.Length != 1)
        {
            throw new HibernateException("insensitive like may only " +
                " be used with single-column properties");
        }
        if (criteriaQuery.Factory.Dialect is PostgreSQLDialect)
        {
            sqlBuilder.Add(columnNames[0]);
            sqlBuilder.Add(" ilike ");
        }
        else
        {
            sqlBuilder.Add(criteriaQuery.Factory.Dialect.LowercaseFunction)
                .Add("(")
                .Add(columnNames[0])
                .Add(")")
                .Add(" like ");
        }
        sqlBuilder.Add(criteriaQuery.NewQueryParameter(
            GetParameterTypedValue(criteria, criteriaQuery)).Single());
        return sqlBuilder.ToSqlString();
    }
