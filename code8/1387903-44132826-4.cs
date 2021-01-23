    public static IFormFile AsMockIFormFile(this FileInfo physicalFile) {
        var fileMock = new Mock<IFormFile>();
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(physicalFile.OpenRead());
        writer.Flush();
        ms.Position = 0;
        var fileName = physicalFile.Name;
        //Setup mock file using info from physical file
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(ms.Length);
        fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
        fileMock.Setup(m => m.ContentDisposition).Returns(string.Format("inline; filename={0}", fileName));
        //...setup other members (code removed for brevity)
        return fileMock.Object;
    }
