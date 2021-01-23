    public interface IRepository<T> {
        T Get(int id);
    }
    public abstract class BaseRepo<T> : IRepository<T> {}
    public class PersonRepo : BaseRepo<Person> {
         Person IPersonRepo.Get(int id) {
             // Get from DB
         }
    }
