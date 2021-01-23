    class D
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
    }
    [....]
    D d = new D();
    PropertyInfo[] typeProperties = d.GetType().GetProperties();
    foreach(string propertyName in new string[] { "a", "b", "c"}) {
        int myValue = 1; // for example
        typeProperties.Single(p => p.Name == propertyName).SetValue(d, myValue);
    }
