       private static List<Category> GetCategories() {
           var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Cars"
                },
                // The rest of the categories here...
            };
            return categories;
        }
