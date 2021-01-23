    public static class TestableObjectFactory {
    	public static T Create<T>() {
    		return FormatterServices.GetUninitializedObject(typeof(T)).CastTo<T>();
    	}
    }
