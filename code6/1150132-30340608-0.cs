    public abstract class BaseClass
    {
        public abstract string Request { get; }
    }
    class ExtendClass : BaseClass
    {
	    public override string Request { get {return "ExtendClass"; } }
    }
