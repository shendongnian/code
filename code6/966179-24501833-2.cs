    // Set (change) the NameFormat of a dataflow block after construction
    public void SetNameFormat(IDataflowBlock block, string nameFormat)
    {
        try
        {
            dynamic debugView = block.GetInternalData(Logger);
            if (null != debugView)
            {
                var blockOptions = debugView.DataflowBlockOptions as DataflowBlockOptions;
                blockOptions.NameFormat = nameFormat;
            }
        }
        catch (Exception ex)
        {
            ...
        }
    }
    
    // Get access to the internal data of a dataflow block via its DebugTypeProxy class
    public static dynamic GetInternalData(this IDataflowBlock block)
    {
        Type blockType = block.GetType();
        try
        {
            // Get the DebuggerTypeProxy attribute, which names the debug class type.
            DebuggerTypeProxyAttribute debuggerTypeProxyAttr =
                blockType.GetCustomAttributes(true).OfType<DebuggerTypeProxyAttribute>().Single();
    
            // Get the name of the debug class type
            string debuggerTypeProxyNestedClassName =
                GetNestedTypeNameFromTypeProxyName(debuggerTypeProxyAttr.ProxyTypeName);
    
            // Get the actual Type of the nested class type (it will be open generic)
            Type openDebuggerTypeProxyNestedClass = blockType.GetNestedType(
                debuggerTypeProxyNestedClassName,
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
    
            // Close it with the actual type arguments from the outer (dataflow block) Type.
            Type debuggerTypeProxyNestedClass =
                openDebuggerTypeProxyNestedClass.CloseNestedTypeOfClosedGeneric(blockType);
    
            // Now create an instance of the debug class directed at the given dataflow block.
            dynamic debugView = ExposedObject.New(debuggerTypeProxyNestedClass, block);
    
            return debugView;
        }
        catch (Exception ex)
        {
            ...
            return null;
        }
    }
    
    // Given a (Type of a) (open) inner class of a generic class, return the (Type
    // of the) closed inner class.
    public static Type CloseNestedTypeOfClosedGeneric(
                           this Type openNestedType,
                           Type closedOuterGenericType)
    {
        Type[] outerGenericTypeArguments = closedOuterGenericType.GetGenericArguments();
        Type closedNestedType = openNestedType.MakeGenericType(outerGenericTypeArguments);
        return closedNestedType;
    }
    
    // A cheesy helper to pull a type name for a nested type out of a full assembly name.
    private static string GetNestedTypeNameFromTypeProxyName(string value)
    {
        // Expecting it to have the following form: full assembly name, e.g.,
        // "System.Threading...FooBlock`1+NESTEDNAMEHERE, System..."
        Match m = Regex.Match(value, @"^.*`\d+[+]([_\w-[0-9]][_\w]+),.*$", RegexOptions.IgnoreCase);
        if (!m.Success)
            return null;
        else
            return m.Groups[1].Value;
    }
    // Added to IgorO.ExposedObjectProject.ExposedObject class to let me construct an 
    // object using a constructor with an argument.
    public ExposedObject {
        ...
                
        public static dynamic New(Type type, object arg)
        {
            return new ExposedObject(Create(type, arg));
        }
    
        private static object Create(Type type, object arg)
        {
            // Create instance using Activator
            object res = Activator.CreateInstance(type, arg);
            return res;
    
            // ... or, alternatively, this works using reflection, your choice:
            Type argType = arg.GetType();
            ConstructorInfo constructorInfo = GetConstructorInfo(type, argType);
            return constructorInfo.Invoke(new object[] { arg });
        }
        ...
    }
