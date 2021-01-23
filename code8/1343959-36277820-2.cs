    public interface IWrapper
    {
    	object Data { get; }
    	string[] Metadata { get; }
    }
    
    public class Wrapper<T> : IWrapper
    {
    	public T Data { get; set; }
    	object IWrapper.Data { get { return Data; } }
    	public string[] Metadata { get; set; }
    }
