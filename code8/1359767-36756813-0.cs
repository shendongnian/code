    abstract class AbstractBase<T>
    	where T : BaseClass
    {
    	public abstract T MyProperty { get; set; }
    }
    
    abstract class AbstractBase : AbstractBase<BaseClass>
    {
    }
    class Implementation_A_OfAbstractBase : AbstractBase<InherritedBaseClassA>
    {
    	public override InherritedBaseClassA MyProperty { get; set; }
    }
