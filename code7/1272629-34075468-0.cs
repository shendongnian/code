    public abstract class Repository<T> : IRepository<T> where T : class
    {
       private List<T> context;
    
       public virtual public T Find(int id)
       {
           return context.FirstOrDefault(x => GetId(x) == id);
       }
       public abstract int GetId(T entity);
    }
