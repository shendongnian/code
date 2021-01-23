        private readonly Dictionary<string, Expression<Func<T, object>>> _mappings = new Dictionary<string, Expression<Func<T, object>>>();
        public OrderExpressions<T> Add(Expression<Func<T, object>> expression, string keyword)
        {
            _mappings.Add(keyword, expression);
            return this;
        }
        public Expression<Func<T, object>> this[string keyword]
        {
            get { return _mappings[keyword]; }
        }
    }
