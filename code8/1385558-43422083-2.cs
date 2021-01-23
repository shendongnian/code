    [TestClass]
    public class DataAccessLayerUnitTest {
        [TestMethod]
        public void TestFilter() {
            //Arrange
            var readerMock = new Mock<IDataReader>();
            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader())
                .Returns(readerMock.Object)
                .Verifiable();
            var parameterMock = new Mock<IDbDataParameter>();            
            commandMock.Setup(m => m.CreateParameter())
                .Returns(parameterMock.Object);
            commandMock.Setup(m => m.Parameters.Add(It.IsAny<IDbDataParameter>()))
                .Verifiable();
            var connectionMock = new Mock<IDbConnection>();
            connectionMock
                .Setup(m => m.CreateCommand())
                .Returns(commandMock.Object);
    
            var connectionFactoryMock = new Mock<IDbConnectionFactory>();
            connectionFactoryMock
                .Setup(m => m.CreateConnection())
                .Returns(connectionMock.Object);
    
            var sut = new MyDataAccessClass(connectionFactoryMock.Object);
            var input = "some value";
    
            //Act
            var data = sut.GetData(input);
    
            //Assert
            commandMock.Verify();
        }
    }
