    public class A
    {
        public string Text { get; set; }
    }
    public class B : A { }
    public class C : A { }
    [XmlInclude(typeof(B))]
    [XmlInclude(typeof(C))]
    public class D 
    {
        public object Data { get; set; }
        public string Test = "Test";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var d = new D();
            d.Data = new B() { Text = "Data" };
            var xSer = CreateOverrider(d);
            xSer.Serialize(new StreamWriter(File.OpenWrite("D:\\testB.xml")), d);
        }
        public static XmlSerializer CreateOverrider(D d)
        {
            XmlAttributeOverrides xOver = new XmlAttributeOverrides();
            XmlAttributes attrs = new XmlAttributes();
            attrs.XmlIgnore =  d.Data is B;  
            xOver.Add(typeof(D), "Data", attrs);
            XmlSerializer xSer = new XmlSerializer(typeof(D), xOver);
            return xSer;
        }
    }
