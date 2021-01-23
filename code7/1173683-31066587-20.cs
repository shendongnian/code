    public class Repository : IRepository
    {
       .... 
       private MyDbContext _cont;
    
       public Comment getComment (int Id)
       {
           return _cont.Comments.FirstOrDefault(c => c.Id == Id);
       }
    
       public List<Comments> GetCommentsList(int articleId)
       {
           return _cont.Comments.Where(c => c.ArticleId == aricleId).ToList();
       }
    }
