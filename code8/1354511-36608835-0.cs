    public class MainClass
    {
        public string MainProp { get; set; }
    }
    public class ClassA : MainClass
    {
        public string SomeProp { get; set; }
        public string WidgetValue { get; set; }
    }
    public class ClassB : MainClass
    {
        public string SomeOtherProp { get; set; }
        public string WidgetValue { get; set; }
    }
    public class ClassC : MainClass
    {
        public string AnotherProp { get; set; }
        public string WidgetValue { get; set; }
    }
    public class ClassD : MainClass
    {
        public string Different { get; set; }
    }
