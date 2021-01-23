	public static class ExpressionFactory
    {
		private static StandardExpression _standardExpression = new StandardExpression();
		
        private static ICustomExpression[] _specialExpressions = new []
        {
            (ICustomExpression)new NullExpression(),
            (ICustomExpression)new LikeExpression()
        };
        
        public static ICustomExpression GetBy(Filter filter)
        {
            var match = _specialExpressions.SingleOrDefault(e => e.ExpressionIsValid(filter));
			
			if (match == null)
				return _standardExpression;
			
			return match;
        }
    }
