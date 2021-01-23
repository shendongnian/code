    public class ParameterlessInExpression : AbstractCriterion
    {
        private readonly IProjection _projection;
        private readonly object[] _values;
    
        /// <summary>
        /// Builds SQL 'IN' expression without using parameters
        /// NB: values must be an array of integers to avoid SQL-Injection.
        /// </summary>
        public ParameterlessInExpression(IProjection projection, int[] values)
    	{
    		_projection = projection;
            _values = values.Select(v => (object)v).ToArray();
    	}
    
        public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            if (_values.Length == 0)
                return new SqlString("1=0");
    
            var result = new SqlStringBuilder();
            var columnNames = CriterionUtil.GetColumnNames(null, _projection, criteriaQuery, criteria, enabledFilters);    
    
            for (int columnIndex = 0; columnIndex < columnNames.Length; columnIndex++)
            {
                SqlString columnName = columnNames[columnIndex];
    
                if (columnIndex > 0)
                    result.Add(" and ");
    
                result.Add(columnName).Add(" in (").Add(StringHelper.ToString(_values)).Add(")");
            }
    
            return result.ToSqlString();
        }
    
        // ...
        // some non-essential overrides omitted here
        // ...
    }
