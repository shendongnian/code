    class myApplication
    {
        // ...
        public void DoSomething(BaseClass arg)
        {
    		var type = arg.GetType();
    		// Check whether a generic type was passed
    		if (type.IsGenericType)
    		{
    			var genType = type.GetGenericTypeDefinition();
    			// Check whether it is of type A<>
    			if (genType == typeof(A<>))
    			{
    				// Get generic argument type
    				var genArg = type.GenericTypeArguments[0];
    				// Create a default instance; might not work under all circumstances
    				// Better to get the method parameter in another way
    				var mthArg = Activator.CreateInstance(genArg);
    				// Get method that is to be called
    				var mth = type.GetMethod("F");
    				// Invoke method dynamically
    				mth.Invoke(arg, new object[] { mthArg });
    			}
    		}
        }
    }
