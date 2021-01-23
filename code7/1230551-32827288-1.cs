    public class Foo<T>
    {
        public Foo() {}
        public Foo(T obj, IEnumerable<Qux> quxs, string quxPropName)
        {
            var fooProps = GetType().GetProperties().ToList();
            var tProps = typeof(T).GetProperties()
                .Where(p =>
                {
                    var w = fooProps.FirstOrDefault(f => f.Name == p.Name);
                    return w != null;
                }).ToList();
    
            foreach (var propertyInfo in tProps)
            {
                var val = propertyInfo.GetValue(obj, null);
                fooProps.First(e => e.Name == propertyInfo.Name).SetValue(this, val, null);
            }
            int id = (int)typeof(T).GetProperty(quxPropName).GetValue(obj, null);
            Qux qux = quxs.Single(q => q.ID == id);
            this.FooQux = string.Format("{0} - {1}", qux.ID, qux.Name);
        }
        public bool Selected { get; set; }
        public int ID { get; set; }
        public bool Active { get; set; }
        public string FooQux { get; set; }
    }
