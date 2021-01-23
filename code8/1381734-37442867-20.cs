    public class CategoryCachedRouteDataProvider : ICachedRouteDataProvider<int>
    {
        private readonly ICategorySlugBuilder categorySlugBuilder;
        public CategoryCachedRouteDataProvider(ICategorySlugBuilder categorySlugBuilder)
        {
            if (categorySlugBuilder == null)
                throw new ArgumentNullException("categorySlugBuilder");
            this.categorySlugBuilder = categorySlugBuilder;
        }
        public IDictionary<string, int> GetVirtualPathToIdMap(HttpContextBase httpContext)
        {
            var slugs = this.categorySlugBuilder.GetCategorySlugs(httpContext.Items);
            return slugs.ToDictionary(k => k.Slug, e => e.CategoryID);
        }
    }
ProductCachedRouteDataProvider
