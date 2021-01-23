    using System.Reflection;
    using MS.Internal.WindowsBase;
    
    namespace EventTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var test = new Test();
                WeakEventManager<IBase, EventArgs>.AddHandler(test, "IBaseEvent", (s, e) => { }); // works
                WeakEventManager<ITest, EventArgs>.AddHandler(test, "ITestEvent", (s, e) => { }); // works 
                WeakEventManager<Test, EventArgs>.AddHandler(test, "TestEvent", (s, e) => { }); // works
            }
        }
        interface IBase
        {
            event EventHandler IBaseEvent;
        }
    
        interface ITest : IBase { event EventHandler ITestEvent; }
    
        class Test : ITest
        {        
            public event EventHandler IBaseEvent;
            public event EventHandler ITestEvent;
            public event EventHandler TestEvent;
        }
    }
