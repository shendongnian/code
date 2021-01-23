    [TestMethod]
    public async Task Controller_Should_Upload_FormFile() {
        // Arrange.
        var fileMock = new Mock<IFormFile>();
        var physicalFile = new FileInfo("filePath");
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(physicalFile.OpenRead());
        writer.Flush();
        ms.Position = 0;
        var fileName = physicalFile.Name;
        //Setup mock file using info from physical file
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(ms.Length);
        fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
        fileMock.Setup(_ => _.ContentDisposition).Returns(string.Format("inline; filename={0}", fileName));
        //...setup other members as needed.
        var sut = new MyController();
        var file = fileMock.Object;
        // Act.
        var result = await sut.Upload(file);
        //Assert.
        Assert.IsInstanceOfType(result, typeof(IActionResult));
    }
