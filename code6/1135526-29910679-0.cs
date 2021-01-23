    public class CategoryVM
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public bool IsSelected { get; set; }
    }
    public class ArticlesCategoriesViewModel
    {
      public int Id { get; set; }
      ....
      public string Author { get; set; }
      List<CategoryVM> Categories { get; set; }
    }
