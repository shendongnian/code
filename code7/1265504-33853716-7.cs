    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    namespace Examples.Queryables
    {
        public class InterceptingQueryable<T> : IOrderedQueryable<T>
        {
            private readonly Action<T> _interceptor;
            private readonly IQueryable<T> _underlyingQuery;
            private InterceptingQueryProvider _provider;
            public InterceptingQueryable(Action<T> interceptor, IQueryable<T> underlyingQuery)
            {
                _interceptor = interceptor;
                _underlyingQuery = underlyingQuery;
                _provider = null;
            }
            public IEnumerator<T> GetEnumerator()
            {
                return new InterceptingEnumerator(_interceptor, _underlyingQuery.GetEnumerator());
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public Expression Expression 
            {
                get { return _underlyingQuery.Expression; }
            }
            public Type ElementType 
            {
                get { return _underlyingQuery.ElementType; }
            }
            public IQueryProvider Provider 
            {
                get
                {
                    if ( _provider == null )
                    {
                        _provider = new InterceptingQueryProvider(_interceptor, _underlyingQuery.Provider); 
                    }
                    return _provider;
                }
            }
            private class InterceptingQueryProvider : IQueryProvider
            {
                private readonly Action<T> _interceptor;
                private readonly IQueryProvider _underlyingQueryProvider;
                public InterceptingQueryProvider(Action<T> interceptor, IQueryProvider underlyingQueryProvider)
                {
                    _interceptor = interceptor;
                    _underlyingQueryProvider = underlyingQueryProvider;
                }
                public IQueryable CreateQuery(Expression expression)
                {
                    throw new NotImplementedException();
                }
                public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
                {
                    var query = _underlyingQueryProvider.CreateQuery<TElement>(expression);
                    
                    if ( typeof(T).IsAssignableFrom(typeof(TElement)) )
                    {
                        return new InterceptingQueryable<TElement>((Action<TElement>)(object)_interceptor, query);
                    }
                    else
                    {
                        return query;
                    }
                }
                public object Execute(Expression expression)
                {
                    throw new NotImplementedException();
                }
                public TResult Execute<TResult>(Expression expression)
                {
                    var result = _underlyingQueryProvider.Execute<TResult>(expression);
                    
                    if ( result is T )
                    {
                        _interceptor((T)(object)result);
                    }
                    
                    return result;
                }
            }
            private class InterceptingEnumerator : IEnumerator<T>
            {
                private readonly Action<T> _interceptor;
                private readonly IEnumerator<T> _underlyingEnumerator;
                private bool _hasCurrent;
                public InterceptingEnumerator(Action<T> interceptor, IEnumerator<T> underlyingEnumerator)
                {
                    _interceptor = interceptor;
                    _underlyingEnumerator = underlyingEnumerator;
                    _hasCurrent = false;
                }
                public void Dispose()
                {
                    _underlyingEnumerator.Dispose();
                }
                public bool MoveNext()
                {
                    _hasCurrent = _underlyingEnumerator.MoveNext();
                    if ( _hasCurrent )
                    {
                        _interceptor(_underlyingEnumerator.Current);
                    }
                    return _hasCurrent;
                }
                public void Reset()
                {
                    _underlyingEnumerator.Reset();
                }
                public T Current 
                {
                    get
                    {
                        return _underlyingEnumerator.Current;
                    }
                }
                object IEnumerator.Current
                {
                    get { return Current; }
                }
            }
        }
        public static class QueryableExtensions
        {
            public static IOrderedQueryable<T> InterceptWith<T>(this IQueryable<T> query, Action<T> interceptor)
            {
                return new InterceptingQueryable<T>(interceptor, query);
            }
        }
    }
