    [TestClass]
    public class FileParserTest : MiscMoqTests {
        [TestMethod]
        public void Moq_With_Ref_Arguents() {
            //Arrange
            Mock<IFileParser> mockFileParse = new Mock<IFileParser>();
            // ref arguments
            string[] firstline = new string[2] { "1", "2" };
            string[] secondline = null;
            // Only matches if the ref arguments to the invocation are the same instance
            mockFileParse.Setup(m => m.ParseFirstTwoRows(It.IsAny<FileQueue>(), ref firstline, ref secondline)).Verifiable();
            var sut = new MyDummyClass(mockFileParse.Object);
            //Act
            sut.DoSomethingWithRef(ref firstline, ref secondline);
            //Assert
            mockFileParse.Verify();
        }
        public class MyDummyClass {
            private IFileParser fileParser;
            public MyDummyClass(IFileParser fileParser) {
                this.fileParser = fileParser;
            }
            public void DoSomethingWithRef(ref string[] firstRow, ref string[] secondRow) {
                var fq = new FileQueue();
                fileParser.ParseFirstTwoRows(fq, ref firstRow, ref secondRow);
            }
        }
        public interface IFileParser {
            void ParseFirstTwoRows(FileQueue file, ref string[] firstRow, ref string[] secondRow);
        }
        public class FileQueue { }
    }
