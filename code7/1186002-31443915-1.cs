    public interface IInputSource
    { 
    }
    public class InputSource<T> : IInputSource
    {
    }
    
    public void update(IList<IInputSource> inputs)
    {
        IInputSource ip = new InputSource<double>();
        inputs.Add(ip);
    }
