    [AttributeUsage(AttributeTargets.Delegate)]
    public class DelegateTargetAttribute : Attribute
    { }
    
    public class Example
    {
    	[DelegateTarget]
    	public delegate int Foo (string bar);
    }
