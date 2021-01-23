    public class Foo<T>
    {
        public Foo(T obj, Qux qux)
        {
            var baz = obj as Baz;
            var bar = obj as Bar;
            Active = baz != null && baz.Active || bar != null && bar.Active;
            this.FooQux = string.Format("{0} - {1}", qux.ID, qux.Name);
        }
        public bool Selected { get; set; }
        public int ID { get; set; }
        public bool Active { get; set; }
        public string FooQux { get; set; }
    }
