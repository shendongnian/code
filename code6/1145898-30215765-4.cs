    public static MyCategoryExtensions
    {
        public static bool IsNullOrEmpty(this Category category) 
        {
            return category == null || string.IsNullOrEmpty(category.Name);
        }
        public static Category EmptyIfNull(this Category category) 
        {
            return category ?? new Category("");
        }
        public static Category DefaultIfNullOrEmpty(this Category category) 
        {
            return category.IsNullOrEmpty() 
                ? new Category(Category.DefaultName)
                : category;
        }
    }
