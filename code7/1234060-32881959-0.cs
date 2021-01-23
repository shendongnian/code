    class A : System.Dynamic.DynamicObject
    {
        // Other members
        public List<Property> properties;
    
        private readonly Dictionary<string, object> _membersDict = new Dictionary<string, object>();
    
        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
        {
            result = null;
            if (!_membersDict.ContainsKey(binder.Name))
                return false;
    
            result = _membersDict[binder.Name];
            return true;
        }
    
        public override bool TrySetMember(System.Dynamic.SetMemberBinder binder, object value)
        {
            if (!_membersDict.ContainsKey(binder.Name))
                return false;
    
            _membersDict[binder.Name] = value;
            return true;
        }
    
        public void CreateProperties()
        {
            foreach (Property prop in properties)
            {
                if (!_membersDict.ContainsKey(prop.key))
                {
                    _membersDict.Add(prop.key, prop.value);
                }
            }
        }
    }
