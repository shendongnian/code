    using System;
    using Castle.Windsor;
    
    namespace StackOwerflow
    {
        public class Program
        {
            #region  windsor castle
            interface IFoo
            {
                void test();
                void test2();
            }
            public class Foo : IFoo
            {
                private readonly string _arg1;
                private readonly string _arg2;
    
                public Foo(string arg1, string arg2)
                {
                    _arg1 = arg1;
                    _arg2 = arg2;
                }
    
    
                public void test()
                {
                    Console.WriteLine("Success method 1");
                }
                public void test2()
                {
                    Console.WriteLine("arg1: {0}. arg2: {1}", _arg1, _arg2);
                }
            }
            class Bar
            {
                private Foo foo;
    
                public Bar(Foo foo)
                {
                    this.foo = foo;
                }
            }
            static void Main(string[] args)
            {
    
                IWindsorContainer container = new WindsorContainer();            
                container.Install(Castle.Windsor.Installer.Configuration.FromAppConfig());            
    
                IFoo foo = container.Resolve<Foo>("AFooNamedFoo");
                foo.test();
                foo.test2();
                Console.ReadKey();
    
            }
    
            #endregion
        }
    }
