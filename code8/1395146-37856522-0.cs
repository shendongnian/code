    [XmlInclude(typeof(X))]
    [XmlInclude(typeof(Y))]
    public class ParentCls
    {
        public int k;
    }
    public class X : ParentCls
    {
        public string name = "foobar";
    }
    public class Y : ParentCls
    {
        public double price = 32.0;
    }
