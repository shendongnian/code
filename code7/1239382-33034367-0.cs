    public class FooBarTest
    {
        public void DoSomethingWithFooBar<TFooBase, TBarBase>(FooBarHolderAbstract<TFooBase, TBarBase> obj) 
            where TFooBase : FooBase
            where TBarBase : BarBase
        {
            //Do something tith the obj
        }
        public void RunTest()
        {
            DoSomethingWithFooBar<Foo, Bar>(new MyFooBarHolderImpl());
        }
    }
