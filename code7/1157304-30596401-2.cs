    public interface IMyInterface
    {
    }
    public class MyBaseClass:IMyInterface
    {
        public string B()
        {
            return "In Abstract";
        }
    }
    public class MyDerivedClass : MyBaseClass
    {
    }
