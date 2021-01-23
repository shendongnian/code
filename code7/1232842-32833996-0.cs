    public class PropertyCollection : Dictionary<string, string>
    {
        public string PropertyA
        {
            get { return GetValue(); }
            set { StoreValue(value); }
        }
        public string PropertyB
        {
            get { return GetValue(); }
            set { StoreValue(value); }
        }
        protected string GetValue([CallerMemberName] string propName = "")
        {
            if (ContainsKey(propName))
                return this[propName];
            return "";
        }
        protected void StoreValue(string propValue, [CallerMemberName] string propName = "")
        {
            if (ContainsKey(propName))
                this[propName] = propValue;
            else
                Add(propName, propValue);
        }
    }
