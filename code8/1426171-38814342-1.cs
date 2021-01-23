    var user = new User
        {
            Email = "",
            Categories = new YourOwnNamespace.List<Category>
                {
                    new Category
                    {
                        Description = "Category 1",
                    },
                    new Category
                    {
                        Description = "Category 2",
                    }
                }
        };
