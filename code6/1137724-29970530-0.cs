    using InterfaceOne;
    using InterfaceTwo;
    namespace MainObject
    {
        public class TheMainObject
        {
            public TheMainObject(IA obj) { }
            public TheMainObject(IB obj, int x) { }
        }
    }
    
    using InterfaceTwo;
    using MainObject;
    namespace ReferenceTest
    {
        public class ReferenceTest
        {
            public static void DoSomething()
            {
                var a = new A();
                var theMainObject = new TheMainObject(a); //no error
            }
        }
    }
