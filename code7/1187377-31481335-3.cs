    public void SomeMethodInvokerRuntime(Type typeofSomeClass, object obj)
    {
        var _SomeMethod = this.GetType().GetMethod("SomeMethodInvoker", 
    	    BindingFlags.Public | BindingFlags.Static);
        MethodInfo toBeCalled = _SomeMethod.MakeGenericMethod(obj.GetType());
        toBeCalled.Invoke(null, new[]{typeofSomeClass, obj});
    }
    
    public static void SomeMethodInvoker<T>(Type typeofSomeClass, T obj)
    {
        var _SomeMethod = typeofSomeClass.GetMethod("SomeMethod",
              BindingFlags.Public | BindingFlags.Static);
        MethodInfo toBeCalled = _SomeMethod.MakeGenericMethod(typeof(T));
        Func<T> that = () => obj; // Main part - strongly typed delegate
        toBeCalled.Invoke(null, new[]{that});
    }
