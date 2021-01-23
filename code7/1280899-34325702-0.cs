    using System;
    using System.Collections.Generic;
    
    namespace DataAbstractWPF.Helpers
    {
        public class AttributeHelper
        {
    
            public static bool HasAttribute(Type implementation, Type attr)
            {
                object[] arr = implementation.GetCustomAttributes(true);
                List<object> list = new List<object>(arr);
                object attrib = list.Find(delegate (object o) { return ( attr.IsAssignableFrom(o.GetType()) ); });
                return attrib != null;
            }
    
        }
    }
