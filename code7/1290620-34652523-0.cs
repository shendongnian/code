    public static void AddFilterCriteria<T>(this NHibernate.IQueryOver<T,T> _this, IEnumerable<Filter> _filters)
    {
        foreach (var filter in _filters)
        {
            _this.And(GetCriterion(filter));
        }
    }
    public static NHibernate.Criterion.ICriterion GetCriterion(Filter _filter)
    {
        if (_filter.Value is string)
        {
            return GetCriterionForString(_filter);
        }
        switch (_filter.Operator)
        {
            case eFilterOperator.IsEqualTo:
                {
                    return NHibernate.Criterion.Expression.Eq(_filter.Member, _filter.Value);
                }
            case eFilterOperator.IsNotEqualTo:
                {
                    return NHibernate.Criterion.Expression.Not(NHibernate.Criterion.Expression.Eq(_filter.Member, _filter.Value));
                }
            case eFilterOperator.IsGreaterThan:
                {
                    return NHibernate.Criterion.Expression.Gt(_filter.Member, _filter.Value);
                }
            case eFilterOperator.IsGreaterThanOrEqualTo:
                {
                    return NHibernate.Criterion.Expression.Ge(_filter.Member, _filter.Value);
                }
            case eFilterOperator.IsLessThan:
                {
                    return NHibernate.Criterion.Expression.Lt(_filter.Member, _filter.Value);
                }
            case eFilterOperator.IsLessThanOrEqualTo:
                {
                    return NHibernate.Criterion.Expression.Le(_filter.Member, _filter.Value);
                }
            default:
                throw new InvalidOperationException();
        }
    }
