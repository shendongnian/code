    public class LuaTable
    {
        private Dictionary<object, dynamic> properties = new Dictionary<object, dynamic>();
        public dynamic this[object property]
        {
            get
            {
                if (properties.ContainsKey(property))
                    return properties[property];
                LuaTable table = new LuaTable();
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
