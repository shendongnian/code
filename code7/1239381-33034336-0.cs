        public class FooBarTest
        {
            public void DoSomethingWithFooBar<T>() where T : FooBarHolderAbstract<Foo, Bar>
            {
                //Do something tith the obj
            }
    
            public void RunTest()
            {                         
                DoSomethingWithFooBar<MyFooBarHolderImpl>();
            }
        }
