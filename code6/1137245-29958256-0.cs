    public class CategoryUsageCount
    {
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public int UsageCount { get; set; }
    }
    public class UsageCountByCategory : AbstractMultiMapIndexCreationTask<CategoryUsageCount>
    {
        public UsageCountByCategory()
        {
            AddMap<Category>(categories => 
                from category in categories 
                select new {
                    CategoryId = category.Id,
                    Category = category,
                    UsageCount = 0
                });
            AddMap<Procuct>(products =>
                from product in products
                select new {
                    CategoryId = product.Category,
                    Category = (Category)null,
                    UsageCount = 1
                });
            Reduce = results => 
                from result in results
                group result by result.CategoryId into g
                select new {
                    CategoryId = g.Key,
                    Category = g.Select(x => x.Category).Where(x => x != null).First(),
                    UsageCount = g.Sum(x => x.UsageCount)
                };
            Index(x => x.CategoryId, FieldIndexing.Analyzed);
        }
    }
