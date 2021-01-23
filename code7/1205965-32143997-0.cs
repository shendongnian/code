    public interface IWorker<T>
    {
    	bool DoWork(T message);
    }
    
    public class StringWorker : IWorker<string>
    {
    	public bool DoWork(string message)
    	{
    		throw new DivideByZeroException();
    	}
    }
