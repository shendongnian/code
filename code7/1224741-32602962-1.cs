    public class A
    {
        public B BObject { get; set; }
        public A()
        {
            var BTypeProperties = this.GetType().GetProperties().Where(x => x.PropertyType == typeof(B));
            foreach (var prop in BTypeProperties)
            {
                prop.SetValue(this, new B(prop.Name));
            }
        }
    }
    public class B
    {
        string _propName;
        public B(string propertyName)
        {
            _propName = propertyName;
        }
    }
