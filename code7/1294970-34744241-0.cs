	public struct S
	{
		public string Value {get; set;}
	}
	
	static class Program
	{	
		
	    public delegate void RefAction<T, TParam>(ref T arg, TParam param);
	    static RefAction<object, object> ToOpenActionDelegate<T, TParam>(System.Reflection.MethodInfo methodInfo)
	    {
	        // Convert the slow MethodInfo into a fast, strongly typed, open delegate
	        Type objectType = typeof(T);
	        Type parameterType = typeof(TParam);
	        RefAction<object, object> ret;
	        if (objectType.IsValueType)
	        {
	            RefAction<T, TParam> propertySetter = (RefAction<T, TParam>)Delegate.CreateDelegate(typeof(RefAction<T, TParam>), null, methodInfo);
	
	            // we are trying to set some struct internal value.
	            ret = (ref object target, object param) =>
	            {
	                T boxed = (T)target;
	                propertySetter(ref boxed, (TParam)System.Convert.ChangeType(param, parameterType));
	                target = boxed;
	            };
	        }
	        else
	        {
	            Action<T, TParam> action = (Action<T, TParam>)Delegate.CreateDelegate(typeof(Action<T, TParam>), null, methodInfo);
	            ret = (ref object target, object param) => action((T)target, (TParam)System.Convert.ChangeType(param, parameterType));
	        }
	
	        return ret;
	    }
		
		public static void Main(string[] args)
		{
			var s = new S();
			
			var mi = s.GetType().GetMethod("set_Value");
			/*
			var deleg = (RefAction<S, string>)Delegate.CreateDelegate(typeof(RefAction<S, string>), null, mi);
			
			deleg(ref s, "hello");
			
			RefAction<object, object> deleg2 = (ref object target, object param) => {
				S boxed = (S)target;
				deleg(ref boxed, (string)param);
				target = boxed;
			};
			*/
			
			RefAction<object, object> deleg2 = ToOpenActionDelegate<S, string>(mi);
			
			var o = (object)s;
			
			deleg2(ref o, "world");
			
			s = (S)o;
			
			Console.WriteLine(s.Value); //prints "world"
			
			Console.ReadKey(true);
		}
	}
