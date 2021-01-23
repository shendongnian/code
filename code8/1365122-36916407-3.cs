    [TestClass]
    public partial class DbTests {
        protected DbContext db;    
        [TestInitialize]
        public virtual void Init() { 
            //Virtual so it could be overridden in derived classes if needed.
            //...check the DB-access code is doing the right thing. 
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
