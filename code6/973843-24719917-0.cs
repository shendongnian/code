    public class ArticleModel 
    {
         public string Title { get; set; }
         public string Body { get; set; }
         public IEnumerable<CommentModel> Comments { get; set; }
    }
    public class CommentModel 
    {
         public string Body { get; set; }
         public string UserName { get; set; }
    }
