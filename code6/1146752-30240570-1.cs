    public interface IBaseRepository<T>
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Create(T element);
        // and so on...
    }
