    [KnownType("GetKnownTypes")]
    public abstract class Foo
    {
    	public static Type[] GetKnownTypes()
    	{
    		Type currentType = MethodBase.GetCurrentMethod().DeclaringType;
            return currentType.Assembly.GetTypes()
                                       .Where(t => t.IsSubclassOf(currentType))
                                       .ToArray();
    	}
    }
