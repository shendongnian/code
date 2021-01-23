    public class Category_Items_Count : AbstractIndexCreationTask<Item, Category_Items_Count.Result>
    {
        public class Result
        {
            public string CategoryId { get; set; }
            public int Count { get; set; }
        }
        public Category_Items_Count()
        {
            Map = items => from item in items
                
                select new Result
                {
                    CategoryId = item.CategoryId,
                    Count = 1
                };
            Reduce = results => from result in results
                group result by result.CategoryId
                into c
                select new Result
                {
                    CategoryId = c.Key,
                    Count = c.Sum(x => x.Count)
                };
        }
    }
