    interface IMyinterface
    {
        void myfunc();
    }
    abstract class MyClassA : IMyinterface
    {
        public void myfunc()
        {
            Console.WriteLine("myfunc in MYClassA");
        }
    }
    class MYClassB : MyClassA
    {
        public new void myfunc()
        {
            Console.WriteLine("myfunc in MYClassB");
        }
    }
