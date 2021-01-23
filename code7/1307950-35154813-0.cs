     public abstract class Filter<T, R>
        {
            protected abstract R GetResult(T input);
    
            private class JoinedFilterIf<S> : Filter<T, S> where S : R
            {
                private readonly Filter<T, R> _left;
                private readonly Filter<R, S> _right;
                private readonly Func<R, bool> _condition;
    
                public JoinedFilterIf(Filter<T, R> left, Filter<R, S> right, Func<R, bool> condition)
                {
                    _left = left;
                    _right = right;
                    _condition = condition;
                }
    
                protected override S GetResult(T input)
                {
                    var result = _left.GetResult(input);
                    return _condition(result) ? _right.GetResult(result) : (S)(result);
                }
            }
        }
