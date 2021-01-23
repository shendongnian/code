    public class MyClass
    {
        [Browsable(false)]
        public List<String> SomeList { get; set; }
        public MyClass(List<String> list)
        {
            SomeList = list;
        }
        [Editor(typeof(MyUITypeEditor), typeof(UITypeEditor))]
        public string SomeValue { get; set; }
    }
