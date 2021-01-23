    public class ObjectAdapter
    {
        public ObjectAdapter()
        {
            MemberFilter = DefaultFilter;
        }
    
        public Predicate<PropertyInfo> MemberFilter { get; set; }
    
        public virtual bool DefaultFilter(PropertyInfo info)
        {
            if (info.Name != "Test")
                return true;
            else
                return false;
        }
    }
