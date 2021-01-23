    public object run(string typename, Stream stream)
    {
            var ttype = Assembly
                     .GetExecutingAssembly()
                     .GetTypes()
                     .FirstOrDefault(x => x.Name == typename);
            MethodInfo minfo = typeof(MyClass)
                  .GetMethod("MyMethod", BindingFlags.Static | BindingFlags.Public);
            return minfo
                 .MakeGenericMethod(ttype)
                 .Invoke(null, new object[] { stream });
    }
