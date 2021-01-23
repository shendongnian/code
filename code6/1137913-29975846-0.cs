    namespace ConsoleTests
    {
    using TestDeferrment = Class1.test;
    
        public class Class1
        {
            public enum test
            {
                test,
                live
            }
        }
    
        public class Class2
        {
            public void x()
            {
                TestDeferrment t = TestDeferrment.live;
            }
        }
    }
