        public static bool IsOfAnyType<T>(T obj, Type[] types)
    	{
            bool isOfAnyType = false;
    		
            for (int i = 0; i < classes.Length; i++)
    		{
    			if (types[i].IsAssignableFrom (obj.GetType()))
    			{
    				isOfAnyType = true;
    				break;
    			}
    		}
             return isOfAnyType;
          }		
