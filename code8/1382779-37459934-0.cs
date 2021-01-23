    try
    {
         Type type = Type.GetType("abc");
         Object obj = Activator.CreateInstance(type);
         MethodInfo methodInfo = type.GetMethod("xyz");
         object[] parameters = { new object[] { Json } };
         response = (methodInfo.Invoke(obj, parameters));
    }
    catch (Exception ex)
    {
         Debug.WriteLine(ex.Message);
    }
