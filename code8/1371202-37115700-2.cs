    public class CategoryModel
    {
        public CategoryModel()
        {
            AppModels = new List<AppModel>();
        }
        [Key]
        public int id { get; set; }
        public string Name {get; set; }
        public virtual ICollection<AppModel> AppModels { get; set; }
    }
    public class AppModel
    {
        public AppModel()
        {
            // Not sure if this is actually needed anymore. But EF usually adds it.
            CategoryModels = new List<CategoryModel>();
        }
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CategoryModel> CategoryModels { get; set; }
    }
