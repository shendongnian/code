     public static GridFilters ParseGridFilters(Dictionary<string,string> data, MyClass myClass)
        {
            foreach (KeyValuePair<string, string> kvp in data)
            {
                Type t = typeof(MyClass);
                var prop = t.GetProperty(kvp.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                prop.SetValue(myClass, kvp.Value, null);
            }
            return myClass;
        }
