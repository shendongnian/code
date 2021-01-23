    [TestClass]
    public class DirectoryFinderTests
    {
        [TestMethod]
        public void ShouldFindDirectoryInGivenDrive()
        {
            // Given
            var drive = "C:/";
            var folderName = "Projects";
            // When
            var finder = new DirectoryFinder();
            var result = finder.FidDirectory(drive, folderName);
            // Then
            Assert.IsTrue(result);
        }
    }
