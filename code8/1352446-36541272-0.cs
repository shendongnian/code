    public class MyDictionary:Dictionary<Foo, int>
    {
        public Bar():base()
        {
        }
        new public int this[string key]
        {
            get
            {
                return this[base.Keys.Single(a => a.Name == key)];
            }
        }
    }
