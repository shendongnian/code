    public class MyClass<T> :
        IGenericContract<T>, INonGenericContract where T : class
    {
        public IQueryable<T> GetAll()
        {
            return null;
        }
        public string GetFullName(Guid guid)
        {
            return null;
        }
    }
