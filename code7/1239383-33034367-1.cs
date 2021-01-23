    public class FooBarTest
    {
        public void DoSomethingWithFooBar<TFooBase, TBarBase, THolder>() 
            where TFooBase : FooBase
            where TBarBase : BarBase
            where THolder : FooBarHolderAbstract<TFooBase, TBarBase>
        {
            //Do something tith the obj
        }
        public void RunTest()
        {
            DoSomethingWithFooBar<Foo, Bar, MyFooBarHolderImpl>();
        }
    }
