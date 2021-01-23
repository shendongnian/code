    public interface IRepository<T> {
        IQueryable<T> GetAllQueryable();
    }
    interface IBlogPostRepository : IRepository<BlogPost> { /* ... */ }
    interface IBlogViewRepository : IRepository<BlogView> { /* ... */ }
