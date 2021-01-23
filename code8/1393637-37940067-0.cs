    using Microsoft.Practices.Unity;
    using System;
    
    namespace Unity
    {  
        interface IFooBar
        {
            string Message();
        }
        class Foo
        {
            string msg;
    
            public Foo()
            {
                msg = "Hello";
            }
    
            public override string ToString()
            {
                return msg;
            }
        }
        class Bar
        {
            private Foo _f;
            private IFooBar _fb;
            public Bar(Foo f, IFooBar fb)
            {
                this._f = f;
                this._fb = fb;
            }
    
            public override string ToString()
            {
                return _f.ToString() + " World " + _fb.Message();
            }
        }
        class FooBar : IFooBar
        {
            public string Message()
            {
                return "Unity!";
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                UnityContainer container = new UnityContainer();
                container.RegisterType<IFooBar, FooBar>(); // required
                container.RegisterType<Foo>(); // optional
                container.RegisterType<Bar>(); // optional
    
                var mybar = container.Resolve<Bar>();
    
                Console.WriteLine(mybar);
            }
        }
    }
