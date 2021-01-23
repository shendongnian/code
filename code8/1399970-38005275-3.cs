    [TestClass]
    public class MyDataTests
    {
        [TestMethod]
        public void GetDataTest()
        {
            const string expectedDisplayMessage = "Please Enter your Name(only Alphabet)";
            const string readString = "test";
            var consoleMock = new Mock<IConsoleMethods>();
            consoleMock.Setup(c => c.ReadLine()).Returns(readString);
            var dd = new MyData(consoleMock.Object);
            dd.GetData();
            //Check that writeline was called twice
            consoleMock.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Exactly(2));
            //Check that writeline was called with you display message
            consoleMock.Verify(c=>c.WriteLine(expectedDisplayMessage), Times.Once);
            //check that Readline was called once
            consoleMock.Verify(c=>c.ReadLine(),Times.Once);
            //Check that writeline was called with your test string once
            consoleMock.Verify(c=>c.WriteLine(readString), Times.Once);
        }
    }
