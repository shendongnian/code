    [TestClass]
    public class UnitTest1
    {
        [TestMethod
        #if !Ignore
        , Ignore()
        #endif
        ]
        public void TestMethod1()
        {
            
        }
        [TestMethod
        #if !Ignore
        , Ignore()
        #endif
        ]
        public void TestMethod2()
        {
        }
    }
 
