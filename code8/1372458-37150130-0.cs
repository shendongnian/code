    public interface IFoo
    {
    	void M();
    }
    
    public interface IBar : IFoo { }
    public interface IQux : IBar, IFoo { }
    public interface IQux2 : IBar { }
    
    // Both work:
    // class X : IQux
    class X : IQux2
    {
    	void IFoo.M() { }
    }
