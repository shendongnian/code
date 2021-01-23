    public static class CustomProjections
    {
        public static ProjectionWithGroupByWithoutSelectProjection GroupByWithoutSelect(IProjection projection, params Expression<Func<object>>[] groupByExpressions)
        {
            var projectionRet = new ProjectionWithGroupByWithoutSelectProjection();
            projectionRet.Add(projection);
            foreach (var groupByExpression in groupByExpressions)
            {
                projectionRet.Add(Projections.Group(groupByExpression));
            }
            return projectionRet;
        }
    }
    public class ProjectionWithGroupByWithoutSelectProjection : IProjection
    {
        // because ProjectionList constructor is protected internal
        private class ProjectionListCustom : ProjectionList
        {
        }
        private readonly ProjectionList _projectionList = new ProjectionListCustom();
        protected internal ProjectionWithGroupByWithoutSelectProjection()
        {
        }
        public ProjectionWithGroupByWithoutSelectProjection Add(IProjection proj)
        {
            _projectionList.Add(proj);
            return this;
        }
        public ProjectionWithGroupByWithoutSelectProjection Add(IProjection projection, string alias)
        {
            _projectionList.Add(projection, alias);
            return this;
        }
        public ProjectionWithGroupByWithoutSelectProjection Add<T>(IProjection projection, Expression<Func<T>> alias)
        {
            _projectionList.Add(projection, alias);
            return this;
        }
        public IType[] GetTypes(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return _projectionList[0].GetTypes(criteria, criteriaQuery);
        }
        public SqlString ToSqlString(ICriteria criteria, int loc, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            return _projectionList[0].ToSqlString(criteria, loc, criteriaQuery, enabledFilters);
        }
        public SqlString ToGroupSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            return _projectionList.ToGroupSqlString(criteria, criteriaQuery, enabledFilters);
        }
        public string[] GetColumnAliases(int position, ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return _projectionList.GetColumnAliases(position, criteria, criteriaQuery);
        }
        public string[] GetColumnAliases(string alias, int position, ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return _projectionList.GetColumnAliases(alias, position, criteria, criteriaQuery);
        }
        public IType[] GetTypes(string alias, ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return _projectionList[0].GetTypes(alias, criteria, criteriaQuery);
        }
        public string[] Aliases => _projectionList.Aliases;
        public override string ToString()
        {
            return _projectionList.ToString();
        }
        public bool IsGrouped => _projectionList.IsGrouped;
        public bool IsAggregate => _projectionList.IsAggregate;
        public TypedValue[] GetTypedValues(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return _projectionList[0].GetTypedValues(criteria, criteriaQuery);
        }
    }
