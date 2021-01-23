    [TestClass]
    public class DocumentSpecs
    {
        public string Name = "Name";
        public string FilePath = "Path";
        public string FileData = "Data";
        [TestMethod]
        public void AcceptVisitorCorrectly()
        {
            //Arrange
            var document = new DocumentDbReader().GetById(0);
            var visitor = new FakeWebServiceVisitor();
            //Act
            document.Accept(visitor);
            //Assert
            Assert.AreEqual(FileData, visitor.FileData);
            Assert.AreEqual(Name, visitor.Name);
        }
        [TestMethod]
        public void ReplaceFileDataCorrectly()
        {
            //Arrange
            var successActionCalled = false;
            var expectedFileData = Guid.NewGuid().ToString();
            var document = new DocumentDbReader().GetById(0);
            //Act
            var documentInitialData = document.FileData;
            document.ReplaceFileData(expectedFileData, () => successActionCalled = true);
            //Assert
            Assert.IsTrue(successActionCalled);
            Assert.AreEqual(expectedFileData, document.FileData);
            Assert.IsFalse(documentInitialData == document.FileData);
        }    
    }
