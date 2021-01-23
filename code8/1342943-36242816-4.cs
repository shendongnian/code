    public interface ICommonObject
    {
        int Id { get; }
        string Name { get; }        
    }
    public class ObjectOne : ICommonObject
    {
        int Id { get; }
        string Name { get; }
        public ObjectOne(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
    
    public class ObjectTwo : ICommonObject
    {
        int Id { get; }
        string Name { get; }
        public ObjectTwo(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
