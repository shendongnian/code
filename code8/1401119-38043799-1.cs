        	public static bool IsOfAnyType<T>(T object, Type[] types)
    	{
            bool isOfAnyType = false;
    		
            for (int i = 0; i < classes.Length; i++)
    		{
    			if (types[i].IsAssignableFrom (object.GetType()))
    			{
    				isOfAnyType = true;
    				break;
    			}
    		}
    		
             return isOfAnyType;
          }		
