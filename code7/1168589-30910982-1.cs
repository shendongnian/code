    public class BaseClass
    {
        public int PropA { get; set; }
    }
    public class InheritClass : BaseClass
    {
        public int PropB { get; set; }
    }
    public interface IMyInterface
    {
        BaseClass PropClass { get; set; }
    }
    public class MyClassA : IMyInterface
    {
        public BaseClass PropClass { get; set; }
    }
    public class MyClassB : IMyInterface
    {
        private BaseClass _propClass;
        public BaseClass PropClass
        {
            get { return (InheritClass)_propClass; }
            set { _propClass = (InheritClass)value; }
        }
    }
