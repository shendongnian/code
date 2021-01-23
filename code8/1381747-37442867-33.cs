    public class ProductCachedRouteDataProvider : ICachedRouteDataProvider<int>
    {
        private readonly ICategorySlugBuilder categorySlugBuilder;
        public ProductCachedRouteDataProvider(ICategorySlugBuilder categorySlugBuilder)
        {
            if (categorySlugBuilder == null)
                throw new ArgumentNullException("categorySlugBuilder");
            this.categorySlugBuilder = categorySlugBuilder;
        }
        public IDictionary<string, int> GetVirtualPathToIdMap(HttpContextBase httpContext)
        {
            var slugs = this.categorySlugBuilder.GetCategorySlugs(httpContext.Items);
            var result = new Dictionary<string, int>();
            using (var db = new ApplicationDbContext())
            {
                foreach (var product in db.Products)
                {
                    int id = product.ProductID;
                    string categorySlug = slugs
                        .Where(x => x.CategoryID.Equals(product.CategoryID))
                        .Select(x => x.Slug)
                        .FirstOrDefault();
                    string slug = string.IsNullOrEmpty(categorySlug) ?
                        product.UrlSegment :
                        categorySlug + "/" + product.UrlSegment;
                    result.Add(slug, id);
                }
            }
            return result;
        }
    }
CategorySlugBuilder
