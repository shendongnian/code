    public interface IXFactory
    {
        IX GetX(XRequest request);
    }
    public interface IX
    {
        void SomeMethod()
    }
    
    //And I'd do A as an abstract class and rename to XBase
    public class A : IX
    {
        public void SomeMethod() {}
    }
    public class D
    {
        public D(IXFactory xFactory)
        {
            XFactory = xFactory;
        }
        public void SomeMethod()
        {
            var x1 = XFactory.GetX(/*some request to get B*/);
            var x2 = XFactory.GetX(/*some request to get C*/);
        }
        public IXFactory XFactory { get; set; }
    }
