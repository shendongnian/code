    using System;
    
    namespace PythonHelper
    {
        public class Generics
        {
    
            public static Action<T1, T2> GetAction<T1, T2>(Func<T1, T2, object> method)
            {
                return (a, b) => method(a,b);
            }
    
        }
    }
