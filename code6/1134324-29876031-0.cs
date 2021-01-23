    public class ItemCategoryTransformer : AbstractTransformerCreationTask<Item>
    {
        public ItemCategoryTransformer()
        {
            TransformResults = results => from item in results
                                          let category = LoadDocument<Category>(item.CategoryId)
                                          select new ItemCategoryViewModel
                                          {
                                              Name = item.Name,
                                              CategoryName = category.Name
                                          };
        }
    }
    public class ItemCategoryViewModel
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
