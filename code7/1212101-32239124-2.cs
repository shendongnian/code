	public void CallFunction(Type type, string methodToCall, params object[] args)
	{
		var delegate_wrapper = new Func<object, object>(
			instance => type.InvokeMember(methodToCall, BindingFlags.InvokeMethod, null, instance, args)
			);
	    var target_method = type.GetMethod(methodToCall);
		
	    var mc_custom_type = typeof (MethodCaller<>).MakeGenericType(type);
	    var mc_instance = Activator.CreateInstance(mc_custom_type);
	    var mc_custom_method = mc_custom_type.GetMethod("Do").MakeGenericMethod(target_method.ReturnType);
		
	    mc_custom_method.Invoke(mc_instance, new object[] { delegate_wrapper });
	}
	public class MethodCaller<TParm> where TParm : new()
	{
		public TResult DoTyped<TResult>(Func<TParm, TResult> func)
	    {
	        return Do<TResult>(oinstance=>func((TParm)oinstance));
	    }
	    public TResult Do<TResult>(Func<object, object> func)
	    {
			Console.WriteLine("I AM DO");
	        return (TResult)func(new TParm());
	    }
	}
 
