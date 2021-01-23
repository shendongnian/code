    public interface IMyTable 
    {
        IEnumerable<MyTable> findAll();
        // other methods
    }
    public class MyTable : IMyTable 
    {
        // your implementation
    }
