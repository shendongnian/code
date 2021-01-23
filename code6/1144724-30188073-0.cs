    public class Category_Items : AbstractMultiMapIndexCreationTask<Category_Items.ReduceResult>
    {
        public class ReduceResult
        {
            public string CategoryId { get; set; }
            public int Count { get; set; }
        }
        public Category_Items()
        {
            AddMap<Item>(items =>
                from item in items
                select new 
                {
                    CategoryId = item.CategoryId,
                    Count = 1
                });
            AddMap<Category>(categories =>
                from category in categories
                select new 
                {
                    CategoryId = category.Id,
                    Count = 0
                });
            Reduce = results =>
                from result in results
                group result by result.CategoryId into g
                select new ReduceResult
                {
                    CategoryId = g.Key,
                    Count = g.Sum(x => x.Count)
                };
        }
    }
