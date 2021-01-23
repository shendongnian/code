     public static int GetTypeDistance<T, B>(T t, B baseType)
     {
            if (t is B) // checking if t inherits baseType
            {
                int distance = 0;
                Type curType = t.GetType();
                while (curType != typeof(B) && curType != null)
                {
                    distance++;
                    curType = curType.BaseType;                  
                }
                return distance;
            }
            else { throw new Exception("..."); }            
    }
