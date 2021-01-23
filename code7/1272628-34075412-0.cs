    public interface IEntity
    {
        int Id { get; }
    }
    
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private List<T> context;
    
        virtual public T Find(int id)
        {
            return context.SingleOrDefault(p => p.Id == id);
        }
    }
