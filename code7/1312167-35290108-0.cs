    public class MyPublicClass
    {
        public void DoSomething()
        {
            var myInternalClass = new MyInternalClass();
            myInternalClass.DoSomething();
        }
    }
    internal class MyInternalClass
    {
        public void DoSomething()
        {
        }
    }
