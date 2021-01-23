    public class CustomObject
    {
        Dictionary<string, object> _properties = new Dictionary<string, object>();
        public CustomObject(dynamic parentObject, List<string> properties)
        {
            foreach (string propertyName in properties)
                _properties[propertyName] = parentObject.GetType().GetProperty(propertyName).GetValue(parentObject, null);
        }
        public object this[string name]
        {
            get
            {
                if (_properties.ContainsKey(name))
                {
                    return _properties[name];
                }
                return null;
            }
            set
            {
                _properties[name] = value;
            }
        }
    }
