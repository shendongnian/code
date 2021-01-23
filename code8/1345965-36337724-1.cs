    class BaseClass
    {
        public string P1 {get;set;}
        public string P2 { get; set; }
        public BaseClass()
        {
            P1 = "v1";
            P2 = "v2";
        }
        public override string ToString()
        {
            return GetType().Name + ".Properties: " + string.Join(",", GetType().GetProperties(
                BindingFlags.Public | BindingFlags.Instance).Select(p => $"{p.Name}:{p.GetValue(this)}"));
        }
    }
    
    class DerivedClass : BaseClass
    {
        public string P3 { get; set; }
        public DerivedClass() : base()
        {
            P2 = "update";
            P3 = "v3";
        }
    }
