    public class CategoryItemsCountTransformer : AbstractTransformerCreationTask<Category_Items_Count.Result>
    {
        public CategoryItemsCountTransformer()
        {
            TransformResults = results => from result in results
                let category = LoadDocument<Category>(result.CategoryId)
                select new CategoryItemsCountViewModel
                {
                    CategoryName = category.Name,
                    NumberOfItems = result.Count
                };
        }
    }
    public class CategoryItemsCountViewModel
    {
        public string CategoryName { get; set; }
        public int NumberOfItems { get; set; }
    }
