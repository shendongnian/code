    public class RuleWrapper<T> : IRule<object>
    {
        private readonly IRule<T> inner;
        public RuleWrapper(IRule<T> inner)
        {
            this.inner = inner;
        }
        
        public bool IsBroken(object obj)
        {
            return obj is T && this.inner.IsBroken((T)obj);
        }
    }
