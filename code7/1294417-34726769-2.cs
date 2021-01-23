    public class BaseEnum
    	static BaseEnum()
    	{
    		// from the types defined in current assembly
    		Assembly.GetExecutingAssembly().DefinedTypes
    			// for those who are BaseEnum or its derived
    			.Where(x => typeof(BaseEnum).IsAssignableFrom(x))
    			// invoke their static ctor
    			.ToList().ForEach(x => System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(x.TypeHandle));
    	}
    }
