        public interface IMethod<T>
        {
             void Add<T>(T obj);
             List<T> Get<T>();
             void Update<T>(T obj);
             void Delete<T>(T obj);
        }
    
