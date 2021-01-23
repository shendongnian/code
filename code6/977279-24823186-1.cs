    public static Category GetCateogryFromType(Types categoryType)
            {
                var memberInfo = typeof(Types).GetMember(categoryType.ToString())
                                                          .FirstOrDefault();
    
                if (memberInfo != null)
                {
                    var attribute = (CategoryAttribute)memberInfo.GetCustomAttributes(typeof(CategoryAttribute), false).FirstOrDefault();
                    if (attribute != null)
                    {
                        return attribute.Category;
                    }
                }
    
                throw new ArgumentException("No category found");
            }
    
            public static IEnumerable<Types> GetCategoryTypes(Category category)
            {
                var values = Enum.GetValues(typeof(Types)).Cast<Types>();
                return values.Where(t => GetCateogryFromType(t) == category);
            }
