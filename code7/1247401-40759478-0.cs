    public class NHibernateExtensionsWrapper : INHibernateExtensionsWrapper
    {
    	public INhFetchRequest<TOriginating, TRelated> Fetch<TOriginating, TRelated>(IQueryable<TOriginating> query,
    		Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
    	{
    		return query.Fetch(relatedObjectSelector);
    	}
    }
