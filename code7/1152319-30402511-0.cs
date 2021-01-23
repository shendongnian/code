    public interface IObject<T>
    {
      Task<T> GetById(int id);
    
      Task<List<T>> GetAll();      
    }
    
    public class MyClass : IObject<MyClass>
    {
      public async Task<MyClass> GetById(int id)
      {
        return null;
      }
    
      public async Task<List<MyClass>> GetAll()
      {
        var results = new List<MyClass>();
        return results;
      }
    }
