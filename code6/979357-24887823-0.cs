    public interface IRepository<T> where T: class
    {
      bool Delete(T entity);
      bool Save(T entity);
    }
