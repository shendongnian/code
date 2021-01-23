    public class Repository<T> where T : new()
    {
        public async Task<T> GetAsync(object key)
        {}
        public async Task<T> DeleteAsync(T t)
        {}
    }
