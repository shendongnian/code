    public class LuaTable<T> where T : class
    {
        private bool isValue;
        private T value = null;
        private Dictionary<object, LuaTable<T>> properties = new Dictionary<object, LuaTable<T>>();
        public static implicit operator LuaTable<T>(T val)
        {
            if (val is LuaTable<T>)
                return (LuaTable<T>)val;
            return new LuaTable<T>() { isValue = true, value = val };
        }
        public static implicit operator T(LuaTable<T> table)
        {
            if (table.isValue)
                return table.value;
            return table;
        }
        public LuaTable<T> this[object property]
        {
            get
            {
                if (isValue)
                    return null;
                if (properties.ContainsKey(property))
                    return properties[property];
                LuaTable<T> table = new LuaTable<T>();
                properties.Add(property, table);
                return table;
            }
            set
            {
                if (!properties.ContainsKey(property))
                    properties.Add(property, value);
                else
                    properties[property] = value;
            }
        }
    }
