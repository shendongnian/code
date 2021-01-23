    public class SampleClass
    {
    	public int AddIntegers(int a, int b)
    	{
    		return a + b;
    	}
    }
	var sampleClass = new SampleClass();
	Expression callExpr = Expression.Call(
        Expression.Constant(sampleClass),
        typeof(SampleClass).GetMethod("AddIntegers", new Type[] { typeof(int), typeof(int) }),
        Expression.Constant(1),
        Expression.Constant(2)
        );
