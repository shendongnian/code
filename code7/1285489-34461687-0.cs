    public class A
    {
    	private void CanOnlyCallMethodInClassB();
    	public static void SetHandlerCanOnlyCallMethodInClassB(ClassB b)
    	{
    		b.MethodFromClassA = CanOnlyCallMethodInClassB;
    	}
    }
    public class B
    {
    	public Action MethodFromClassA { get; set; }
    }
