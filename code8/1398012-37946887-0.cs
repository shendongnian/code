    public interface IBaseRepo<T>
    {
         T Get(int id);
         // ...
    }
    public interface IEmployeeRepo : IBaseRepo<Employee>
    {
         Employee GetByFirstName(string name);
         // ...
    }
