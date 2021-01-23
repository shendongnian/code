    public static class ParameterHandler
    {
    	public static void addParameter<T>(string name, Converter<T> c)
    	{
    		ParameterHandler<T>.addParameter(name, c);
    	}
    }
