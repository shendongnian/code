    public interface ICategorySlugBuilder
    {
        IEnumerable<CategorySlug> GetCategorySlugs(IDictionary cache);
    }
    public class CategorySlugBuilder : ICategorySlugBuilder
    {
        public IEnumerable<CategorySlug> GetCategorySlugs(IDictionary requestCache)
        {
            string key = "__CategorySlugs";
            var categorySlugs = requestCache[key];
            if (categorySlugs == null)
            {
                categorySlugs = BuildCategorySlugs();
                requestCache[key] = categorySlugs;
            }
            return (IEnumerable<CategorySlug>)categorySlugs;
        }
        private IEnumerable<CategorySlug> BuildCategorySlugs()
        {
            var categorySegments = GetCategorySegments();
            var result = new List<CategorySlug>();
            foreach (var categorySegment in categorySegments)
            {
                var map = new CategorySlug();
                map.CategoryID = categorySegment.CategoryID;
                map.Slug = this.BuildSlug(categorySegment, categorySegments);
                result.Add(map);
            }
            return result;
        }
        private string BuildSlug(CategoryUrlSegment categorySegment, IEnumerable<CategoryUrlSegment> categorySegments)
        {
            string slug = categorySegment.UrlSegment;
            if (categorySegment.ParentCategoryID.HasValue)
            {
                var segments = new List<string>();
                CategoryUrlSegment currentSegment = categorySegment;
                do
                {
                    segments.Insert(0, currentSegment.UrlSegment);
                    currentSegment =
                        currentSegment.ParentCategoryID.HasValue ?
                        categorySegments.Where(x => x.CategoryID == currentSegment.ParentCategoryID.Value).FirstOrDefault() :
                        null;
                } while (currentSegment != null);
                slug = string.Join("/", segments);
            }
            return slug;
        }
        private IEnumerable<CategoryUrlSegment> GetCategorySegments()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Categories.Select(
                    c => new CategoryUrlSegment
                    {
                        CategoryID = c.CategoryID,
                        ParentCategoryID = c.ParentCategoryID,
                        UrlSegment = c.UrlSegment
                    }).ToArray();
            }
        }
    }
    public class CategorySlug
    {
        public int CategoryID { get; set; }
        public string Slug { get; set; }
    }
    public class CategoryUrlSegment
    {
        public int CategoryID { get; set; }
        public int? ParentCategoryID { get; set; }
        public string UrlSegment { get; set; }
    }
