    [TestClass]
    public class StoredProcedureUnitTest {
        [TestMethod]
        public void TestRunStoredProc() {
            //Arrange
            var connectionFactory = new Mock<IDbConnectionFactory>();
            //..Setup...
            
            var sut = new MyDataAccessClass(connectionFactory.Object);
            //Act
            var actual = sut.RunStoredProc();
            //Assert
            //...
        }
    }
