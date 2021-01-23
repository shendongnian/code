    public interface IEFBlogRepository
    {
        IEnumerable<Blog> GetAllBlogs( int page, int amount, string sort, string order, ISearchCriteria searchCriteria )
    }
    
    public class EFBlogRepository : IEFBlogRepository
    {
       ...
    }
