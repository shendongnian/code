    public static object CreateInstance(Type pContext, params object[] pArguments) {
       var constructors = pContext.GetConstructors();
       foreach (var constructor in constructors) {
          var parameters = constructor.GetParameters();
          if (parameters.Length != pArguments.Length)
             continue;
          // assumed you wanted a matching constructor
          // not just one that matches the first two types
          bool fail = false;
          for (int x = 0; x < parameters.Length && !fail; x++)
             if (!parameters[x].ParameterType.IsInstanceOfType(pArguments[x]))
                fail = true;
          if (!fail)
             return constructor.Invoke(pArguments);
       }
       return null;
    }
