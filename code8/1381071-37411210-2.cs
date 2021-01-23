    public class MainClass
    {
        List<int> a = new List<int>();
        
        AnotherClass c2 = new AnotherClass(a);
        // pass it to the method
        c.meth1(a);
    }
    public class AnotherClass
    {
        public void meth1(List<int> a2)
        {
              // do something with a2
        }
    }
