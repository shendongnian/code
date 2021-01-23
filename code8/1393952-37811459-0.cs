    public interface IManager<T>
    {
       public List<T> List = new List<T>();
       public List<T> GetAll() { ... }
       public T GetById(string id) { ... }
       public void Edit(string id, T item) { ... }
       public void Delete(string id) { ... }
       public void Add(T item) { ... }
       public void Serialize() { ... }
       public static IManager<T> DeSerialize() { ... }
    }
