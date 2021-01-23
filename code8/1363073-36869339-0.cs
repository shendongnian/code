    [TestClass]
    public class IFormFileUnitTests {
        [TestMethod]
        public async Task Should_Upload_Single_File() {
            //Arrange
            var fileMock = new Mock<IFormFile>();
            //Setup mock file using a memory stream
            var s = "Hello World from a Fake File";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(s);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
            var sut = new MyController();
            var file = fileMock.Object;
            //Act
            var result = await sut.UploadSingle(file);
            //Assert
            Assert.IsInstanceOfType(result, typeof(IActionResult));
        }
    }
