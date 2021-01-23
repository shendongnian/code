    [TestClass]
    public partial class DbTests {
    
        [TestInitialize]
        public void Init() {
            //...do db initialization checks 
        }
    
        [TestClass]
        public class Test1 : DbTests {
            [TestMethod]
            public void Should_Do_Some_Test(){...}
    
            [TestMethod]
            public void Should_Do_Some_Db_Test(){...}
        }
    
        [TestClass]
        public class Test2 : DbTests {
            [TestMethod]
            public void Should_Do_Some_Other_Test(){...}
        }    
    }
