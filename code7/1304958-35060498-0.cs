    public abstract class BaseClass<TIdentifier, TMe>
    	where TMe : BaseClass<TIdentifier, TMe>, new()
    {
    	public virtual TMe Me { get { return (TMe)this; } }
    }
    
    public class A : BaseClass<long, A>
    {
    
    }
