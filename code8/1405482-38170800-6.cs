    [TestClass]
    public class MyTestClass {
    
        public class MyFakeHeaderService : IHeaderService {
            string os;
            public MyFakeHeaderService(string os) {
                this.os = os;
            }
        
            public string GetOsType() {
                return os;
            }
        }
    
        [TestMethod]
        public void TestPostMethod() {
            //Arrange
            IHeaderService headers = new MyFakeHeaderService("FAKE OS TYPE");
            var sut = new MyApiController(headers);
            var model = new TestDTO();
    
            //Act
            sut.Post(model);
    
            //Assert
            //.....
        }
    }
