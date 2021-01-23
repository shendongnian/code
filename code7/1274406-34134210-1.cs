    private static List<Category> _categories;
    public static List<Category> Categories {
        get {
            _categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Cars"
                }
            };
            return _categories;
        }
    }
