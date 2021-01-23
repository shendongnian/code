        	public static bool IsOfType<T>(T object, Type[] types)
    	{
            bool result = false;
    		
            for (int i = 0; i < classes.Length; i++)
    		{
    			if (types[i].IsAssignableFrom (object.GetType()))
    			{
    				isOfType = true;
    				break;
    			}
    		}
    		
             return result;
          }		
