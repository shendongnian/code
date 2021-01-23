    public class ArticleModel {
      public string Title { get; set; } 
      // other article properties
      private IEnumerable<ReviewModel> reviews;
      public IEnumerable<ReviewModel> Reviews {
        get {
          if (reviews == null) {
            // lazy loader to get ReviewModels from your business/domain logic
          }
          return reviews;
        }
      }
    }
    public class ArticlesPageModel {
      public string PageTitle { get; set; }
      
      private IEnumerable<ArticleModel> articles;
      public IEnumerable<ArticleModel> Articles {
        get {
          if (articles == null) {
            // lazy load articles from business/domain logic
          }
          return articles;
        }
      }
    }
