    public class BaseClass
    {
        public virtual List<FirstChild> Childs { get; set; }
    }
    public class FirstChild
    {
        public virtual BaseClass Parent { get; set; }
        public virtual List<SecondChild> Childs { get; set; }
    }
    public class SecondChild
    {
        public virtual FirstChild Parent { get; set; }
        public virtual List<ThirdChild> Childs { get; set; }
    }
    public class ThirdChild
    {
        public virtual SecondChild Parent { get; set; }
        public List<FourthCild> Childs { get; set; }
    }
    public class FourthCild
    {
        public virtual ThirdChild Parent { get; set; }
        public int SomeProperty { get; set; }
    }
