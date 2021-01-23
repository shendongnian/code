    public class Magazine
    {
      public int MagazineId { get; set; }
      public string Name { get; set; }
      public string Publisher { get; set; }
      public List<Article> Articles { get; set; }
    }
    public class Article
    {
      public int ArticleId { get; set; }
      public string Title { get; set; }
      public int MagazineId { get; set; }
      public DateTime PublishDate { get;  set; }
      public Author Author { get; set; }
      public int AuthorId { get; set; }
    }
    public class Author
    {
      public int AuthorId { get; set; }
      public string Name { get; set; }
      public List<Article> Articles { get; set; }
    }
