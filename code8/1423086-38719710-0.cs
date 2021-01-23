    public class TestFormFile : IFormFile
    {
        private string testFileContents;
    
        public TestFormFile(string testFileContent)
        {
            this.testFileContents = testFileContents;
        }
    
        public Stream OpenReadStream()
        {
           return new MemoryStream(Encoding.UTF8.GetString(testFileContents));
        }
        // Implement Other methods and properties.
    }
