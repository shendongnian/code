    public interface IRepository<T>
    {
        T Get(int id);
    }
    public abstract class BaseRepo<T> : IRepository<T>
    {
        public abstract T Get(int id);
    }
    public class PersonRepo : BaseRepo<Person>
    {
        public override Person Get(int id)
        {
            // Get from DB
        }
    }
