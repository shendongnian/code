    public class MyClass : DynamicObject
    {
        private Dictionary<string, object> _dynamicMembers = new Dictionary<string, object>();
        public MyClass(object newProperty1, object newProperty2, object newProperty3)
        {
            ((dynamic)this).NewProperty1 = newProperty1;
            ((dynamic)this).NewProperty2 = newProperty2;
            ((dynamic)this).NewProperty3 = newProperty3;
        }
        public MyClass(object newProperty1, object newProperty2)
        {
            ((dynamic)this).NewProperty1 = newProperty1;
            ((dynamic)this).NewProperty2 = newProperty2;
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _dynamicMembers.Keys.ToArray();
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _dynamicMembers.TryGetValue(binder.Name, out result); 
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dynamicMembers[binder.Name] = value;
            return true;
        }
    }
