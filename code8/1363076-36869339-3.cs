    [TestClass]
    public class IFormFileUnitTests {
        [TestMethod]
        public async Task Should_Upload_Single_File() {
            //Arrange
            var fileMock = new Mock<IFormFile>();
            //Setup mock file using a memory stream
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            var sut = new MyController();
            var file = fileMock.Object;
            //Act
            var result = await sut.UploadSingle(file);
            //Assert
            Assert.IsInstanceOfType(result, typeof(IActionResult));
        }
    }
