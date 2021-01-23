    void Main()
    {
    	var a = new A();
    	Console.WriteLine(GetNoVCall<A, int>(a, z => z.Foo)); // prints 5
    	var b = new B();
    	Console.WriteLine(GetNoVCall<A, int>(b, z => z.Foo)); // prints 5
    	Console.WriteLine(GetNoVCall<B, int>(b, z => z.Foo)); // prints 5
    }
    
    class A
    {
    	public virtual int Foo { get { return 5; } }
    }
    
    class B : A
    {
    	public override int Foo { get { return 7; } }
    }
    
    public static TProp GetNoVCall<TClass, TProp>(TClass c, Expression<Func<TClass, TProp>> f)
    {
    	var expr = f.Body as MemberExpression;
    	var prop = expr.Member as PropertyInfo;
    	var meth = prop.GetGetMethod(true);
    	var src = expr.Expression as ParameterExpression;
    
    	if (src == null || prop == null || expr == null)
    		throw new Exception();
    	
    	var dyn = new DynamicMethod("GetNoVCallHelper", typeof(TProp), new Type[]{ typeof(TClass) }, typeof(string).Module, true);
    	var il = dyn.GetILGenerator();
    	il.Emit(OpCodes.Ldarg_0);
    	il.Emit(OpCodes.Call, meth);
    	il.Emit(OpCodes.Ret);
    	
    	return ((Func<TClass, TProp>)dyn.CreateDelegate(typeof(Func<TClass, TProp>)))(c);
    }
