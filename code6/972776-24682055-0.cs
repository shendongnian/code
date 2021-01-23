    void Main()
    {	
    	var t = Mock.Of<IExample>(x => x.GetAll() == new List<IOtherExample>());
    	t.GetAll().Dump();
    }
    
    // Define other methods and classes here
    public interface IOtherExample
    {
    }
    
    public interface IExample : IGenericExample<IOtherExample>
    {
    
    }
    
    public interface IGenericExample<T>
    {
       IList<T> GetAll();
    }
