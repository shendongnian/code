    class Base
    {
       public static T Make<T>() where T : Base
       {
           if (typeof(T) == typeof(Derived)) 
           {
                return (T)(object)new Derived();
           }
           // obviously more cases in here. just for illustration.
           else
           {
                return null;
           }
       }
    }
