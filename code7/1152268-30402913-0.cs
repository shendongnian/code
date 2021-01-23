    public class categoryList
    {
       public static Dictionary<string, string> getCategories()
       {
           Dictionary<string, string> myList = new Dictionary<string, string>();
           using (ProductContext context = new ProductContext())
           {
               List<CategoryModel> list = 
                       (from c in context.Categories.Include("PropertyName") select c)
                       .ToList<CategoryModel>();
               myList = list
               .GroupBy(c => c.category, StringComparer.OrdinalIgnoreCase)
               .ToDictionary(g => g.Key, g => g.First().category, StringComparer.OrdinalIgnoreCase);
               return myList;
           }
        }
    }
