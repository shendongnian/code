    public class NHibernateExtensionsWrapperMock : INHibernateExtensionsWrapper
    {
    	public INhFetchRequest<TOriginating, TRelated> Fetch<TOriginating, TRelated>(IQueryable<TOriginating> query, Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
    	{
    		return (INhFetchRequest<TOriginating, TRelated>) new NhFetchRequest<TOriginating, TRelated>(query);
    	}
    
    	private class NhFetchRequest<TOriginating, TRelated> : INhFetchRequest<TOriginating, TRelated>
    	{
    		private readonly IQueryable<TOriginating> _query;
    
    		public NhFetchRequest(IQueryable<TOriginating> query)
    		{
    			_query = query;
    		}
    
    		public IEnumerator<TOriginating> GetEnumerator()
    		{
    			return _query.GetEnumerator();
    		}
    
    		IEnumerator IEnumerable.GetEnumerator()
    		{
    			return GetEnumerator();
    		}
    
    		public Expression Expression => _query.Expression;
    
    		public Type ElementType => _query.ElementType;
    
    		public IQueryProvider Provider => _query.Provider;
    	}
    }
