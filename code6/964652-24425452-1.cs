    public class MyClass
    {
        public MyClass()
        {}
        public MyClass(IMyService service)
        {
            Service = service;
        }
        public void RefreshItems()
        {
            Items = Service.Get();
        }
        public IMyService Service { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
