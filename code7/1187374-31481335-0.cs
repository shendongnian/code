     void SomeMethodInvoker<T>(Type typeofSomeClass, T obj)
     {
        _SomeMethod = typeofSomeClass.GetMethod("SomeMethod",
              BindingFlags.Public | BindingFlags.Static);
        MethodInfo toBeCalled = _SomeMethod.MakeGenericMethod(type);
        object obj = Activator.CreateInstance(type);
        Func<T> that = () => obj; // Main part - strongly typed delegate
        toBeCalled.Invoke(null, that);
     }
