    public class ObjectValidator<T> where T : class 
	{
		private List<Expression<Func<T, bool>>> m_rules = new List<Expression<Func<T, bool>>>();
		private List<ValidationResult> m_results = new List<ValidationResult>();
		public ObjectValidator<T> AddRule(Expression<Func<T, bool>> rule)
		{
			// Null check, blah blah
			m_rules.Add(rule);
			return this; // Allows for chaining multiple rules together.
		}
		public List<ValidationResult> Validate(T objectInstance)
		{
			foreach (var rule in m_rules)
			{
				var isValid = rule.Compile()(objectInstance);
				var fieldExpression = rule.Body as BinaryExpression;
				var fieldNameExpression = fieldExpression.Left as MemberExpression;
				string fieldName = fieldNameExpression != null ? fieldNameExpression.Member.Name : "Object";
				var result = new ValidationResult(isValid, fieldName);
				m_results.Add(result);
			}
			return m_results;
		}
	}
