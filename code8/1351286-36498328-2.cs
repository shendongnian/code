    class EqualityDefinitionFactory
    {
        /// <summary>
    	/// Decides which class to instantiate.
    	/// </summary>
    	public static IEqualityDefinition Get(EqualityDefinitions definition)
    	{
    	    switch (definition)
    	    {
    		    case EqualityDefinitions.BlockEquality:
    		        return new BlockEqualityDefinition();
    		    default:
    		        throw new NotImplementedException("Unknown type");
    	    }
    	}
    }
