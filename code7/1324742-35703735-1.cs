            public static SomeAbsProperty<T> CreateObject<T>() where T : class
    		{
    			Type type = typeof(T);
    			if (type == typeof(object))
    			{
    				return new ChildrenProperties() as SomeAbsProperty<T>;
    			}
    			else if (type == typeof(string))
    			{
    				return new ChildrenPropertiesString() as SomeAbsProperty<T>;
    			}
    			else
    			{
    				return null;
    			}
    		}
