    internal class Type
    {
      public int SimpleMethod([In] int obj0, [In] string obj1)
      {
        return obj0 + obj1.Length;
      }
 
      public int MethodCallingSimpleMethod([In] string obj0)
      {
        if (string.IsNullOrEmpty(obj0))
          return 0;
        return ((TestClass) this).SimpleMethod(42, obj0);
      }
    }
