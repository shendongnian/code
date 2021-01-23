    //Empty interface 
    public interface IInputVO { }
    
    //Your generic class now implements the interface
    public class InputVO<T> : IInputVO
    {
    	public bool isEnabled { get; set; }
    	public T Value { get; set; }
    }
