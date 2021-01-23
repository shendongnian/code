    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void TestMethod1()
        {
            var instance = new YourClass();
            
            // create an instance of IDbContext
            var context = new Mock<IDbContext>();
            // create an instance of IDbCommand
            var command = new Mock<IDbCommand>();
            // setup your context and what should be the return of any method you want
            context.Setup(c => c.GetDbCommand(It.IsAny<string>(), It.IsAny<string[]>())).Returns(command.Object);
            // call your method you want to test
            instance.InsertData(context.Object);
            // assert that context methods ar called
            context.Verify(c => c.Connect(), Times.Once);
            context.Verify(c => c.DisConnect(), Times.Once);
            context.Verify(c => c.GetDbCommand(It.IsAny<string>(), It.IsAny<string[]>()), Times.Once);
            // assert that command methods ar called
            command.Verify(c => c.ExecuteNonQuery(), Times.Once);
        }
    }
