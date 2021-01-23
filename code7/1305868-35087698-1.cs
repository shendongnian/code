    public class Params
	{
		private readonly IDictionary<string, object> _params = new Dictionary<string, object>();
		public Params And(Expression<Func<object>> exp)
		{
			var body = exp.Body as MemberExpression;
			_params[body.Member.Name] = exp.Compile().Invoke();
			return this;
		}
		public override string ToString()
		{
			return String.Join(", ", _params.Select(pair => String.Format("{0} = {1}", pair.Key, pair.Value)));
		}
	}
	public Params Parameters(Expression<Func<object>>expr)
	{
		return new Params().And(expr);
	}
