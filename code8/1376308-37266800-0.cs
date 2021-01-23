    void Main()
    {
        // Output: "Base"
    	new BaseEqualityComparer<DerivedClass>().Equals(
    		new DerivedClass(),
    		new DerivedClass());
    }
    
    class BaseClass 
    {
    	public override bool Equals(object that)
    	{
    		Console.WriteLine("Base");
    		return base.Equals(that);
    	}
    }
    class DerivedClass : BaseClass, IEquatable<DerivedClass> 
    {
    	public override bool Equals(object that)
    	{
    		Console.WriteLine("Derived");
    		return base.Equals(that);
    	}
        public bool Equals(DerivedClass that) => base.Equals(that);
    }
    class BaseEqualityComparer<T> : IEqualityComparer<T> 
    	where T : IEquatable<T>
    {
    	public bool Equals(T val1, T val2)
    	{
    		return val1.Equals(val2);
    	}
    
    	public int GetHashCode(T val)
    	{
    		throw new NotImplementedException();
    	}
    }
