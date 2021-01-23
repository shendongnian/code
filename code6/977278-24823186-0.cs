    public class CategoryAttribute : Attribute
        {
            private readonly Category _category;
    
            public Category Category
            {
                get
                {
                    return _category;
                }
            }
    
            public CategoryAttribute(Category category)
            {
                _category = category;
            }
        }
