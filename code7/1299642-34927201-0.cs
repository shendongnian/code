    [Serializable]
    public class SharingConstantProjection : SimpleProjection
    {
        private readonly TypedValue _typedValue;
        private NHibernate.SqlCommand.Parameter _parameter;
        public SharingConstantProjection(object value)
            : this(value, NHibernateUtil.GuessType(value.GetType()))
        {
        }
        public SharingConstantProjection(object value, IType type)
        {
            _typedValue = new TypedValue(type, value, EntityMode.Poco);
        }
        public override bool IsAggregate
        {
            get { return false; }
        }
        public override SqlString ToGroupSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            throw new InvalidOperationException("not a grouping projection");
        }
        public override bool IsGrouped
        {
            get { return false; }
        }
        public override SqlString ToSqlString(ICriteria criteria, int position, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            if (_parameter == null)
                _parameter = criteriaQuery.NewQueryParameter(_typedValue).Single();
            return new SqlString(
                _parameter,
                " as ",
                GetColumnAliases(position, criteria, criteriaQuery)[0]);
        }
        public override IType[] GetTypes(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return new IType[] { _typedValue.Type };
        }
        public override TypedValue[] GetTypedValues(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return new TypedValue[] { _typedValue };
        }
        public override string ToString()
        {
            return (_typedValue.Value ?? "NULL").ToString();
        }
    }
    [Serializable]
    public class MyInsensitiveLikeExpression : AbstractCriterion
    {
        private readonly IProjection _projection;
        private readonly IProjection _value;
        public MyInsensitiveLikeExpression(string propertyName, string value)
            : this(Projections.Property(propertyName), Projections.Constant(value))
        { }
        public MyInsensitiveLikeExpression(string propertyName, IProjection value)
            : this(Projections.Property(propertyName), value)
        { }
        public MyInsensitiveLikeExpression(IProjection projection, IProjection value)
        {
            _projection = projection;
            _value = value;
        }
    
        #region ICriterion Members
        public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            SqlString[] columns = CriterionUtil.GetColumnNames(null, _projection, criteriaQuery, criteria, enabledFilters);
            if (columns.Length != 1)
                throw new HibernateException("Like may only be used with single-column properties / projections.");
            var value = SqlStringHelper.RemoveAsAliasesFromSql(_value.ToSqlString(criteria, 0, criteriaQuery, enabledFilters));
            var dialect = criteriaQuery.Factory.Dialect;
            var builder = new SqlStringBuilder(8)
                .Add(dialect.LowercaseFunction)
                .Add(StringHelper.OpenParen)
                .Add(columns[0])
                .Add(StringHelper.ClosedParen)
                .Add(" like ")
                .Add(dialect.LowercaseFunction)
                .Add(StringHelper.OpenParen)
                .Add(value)
                .Add(StringHelper.ClosedParen);
            
            return builder.ToSqlString();
        }
        public override TypedValue[] GetTypedValues(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return _value.GetTypedValues(criteria, criteriaQuery);
        }
        public override IProjection[] GetProjections()
        {
            return new IProjection[] { _projection };
        }
        #endregion
        public override string ToString()
        {
            return _projection + " like " + _value;
        }
    }
