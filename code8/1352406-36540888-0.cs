    using NHibernate.Linq;    
    namespace YourOwnExtensionsNameSpace
    {
        public static class YourOwnExtensionClass
        {
            public static INhFetchRequest<TOriginating, TRelated> 
                Fetch<TOriginating, TRelated>(
                    this IQueryable<TOriginating> query,
                    Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
            {
                EagerFetchingExtensionMethods.Fetch(query, relatedObjectSelector);
            }
            ...
        }
    }
