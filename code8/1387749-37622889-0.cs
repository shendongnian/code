    using System.Reflection;
    
    namespace ReflectionAndIndexers
    {
        class ReflectionIndexer
        {
            public string StrProp1 { get; set; }
            public string StrProp2 { get; set; }
            public int IntProp1 { get; set; }
            public int IntProp2 { get; set; }
    
            public object this[string s]
            {
                set
                {
                    PropertyInfo prop = this.GetType().GetProperty(s, BindingFlags.Public | BindingFlags.Instance);
                    if(prop != null && prop.CanWrite)
                    {
                        prop.SetValue(this, value, null);
                    }
                }
            }
        }
    }
