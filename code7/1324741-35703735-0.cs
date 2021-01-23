            public static SomeAbsProperty<T> CreateObject<T>() where T : class
    		{
    			Type type = typeof(T);
    			if (type == typeof(object))
    			{
    				return new ChildrenProperties(10) as SomeAbsProperty<T>;
    			}
    			else if (type == typeof(string))
    			{
    				return new ChildrenPropertiesString(20) as SomeAbsProperty<T>;
    			}
    			else
    			{
    				return null;
    			}
    		}
