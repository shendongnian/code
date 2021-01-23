    public class OrderExpressions<T>
    {
        private readonly Dictionary<string,Func<T,object>> _mappings = 
            new Dictionary<string,Func<T, object>>();
        public OrderExpressions<T> Add(Func<T, object> expression, string keyword)
        {
            _mappings.Add(keyword, expression);
            return this;
        }
        public Func<T, object> this[string keyword]
        {
            get { return _mappings[keyword]; }
        }
    }
