    try
    {
     Type type = Type.GetType("abc");
     Object obj = Activator.CreateInstance(type);
     MethodInfo methodInfo = type.GetMethod("xyz");
     object[] parameters = { new object[] { Json } };
     response = (methodInfo.Invoke(obj, parameters));
    }
    catch (TargetInvocationException ex)
    {
        ex = ex.InnerException; // ex now stores the original exception
    }
