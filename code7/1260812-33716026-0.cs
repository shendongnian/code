    public class MyControl : UserControl
    {
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string MyProperty { get; set; }
    }
