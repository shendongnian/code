    public class ObjectAdapter
    {
        public ObjectAdapter()
        {
            MemberFilter = DefaultFilter;
        }
    
        public Func<PropertyInfo, bool> MemberFilter { get; set; }
    
        public virtual bool DefaultFilter(PropertyInfo info)
        {
            if (info.Name != "Test")
                return true;
            else
                return false;
        }
    }
