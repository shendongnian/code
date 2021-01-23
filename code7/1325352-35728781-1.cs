    public class A
    {
        public A()
        {
        }
        public A(B inhClass)
        {
            foreach (var prop in typeof(A).GetProperties())
            {
                PropertyInfo myPropInfo = typeof(B).GetProperty(prop.Name);
                prop.SetValue(this, myPropInfo.GetValue(inhClass, null), null);
            }
        }
        public string a { get; set; }
    }
    public class B:A
    {
        public string b { get; set; }
        public A baseclass
        {
            get
            {
                return new A(this);
            }
        }
        
    }
