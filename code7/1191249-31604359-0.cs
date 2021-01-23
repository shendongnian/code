    public static class MyExtClass
        {
            // the "IsNull" extension to "object"  
            public static bool IsNull(this object obj)
            {
                return object.ReferenceEquals(obj, null);
            }
    
        }
    
        public class SomeOtherClass
        {
            public static void TryUsingTheExtension()
            {
                object obj =null;
                           
                bool itIsANull = obj.IsNull();
            }
    
        }
