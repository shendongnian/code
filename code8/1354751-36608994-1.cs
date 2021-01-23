    public class TestFileNotFound : Test<FileTypeNotRecognizedException>
    {
        [Theory]
        [InlineAutoMoqData("bork")]
        public override void Build_ReturnsSpecificException_FileNamePassedIn(string fileName,
            ProcessFactory sut)
        {
            base.Build_ReturnsSpecificException_FileNamePassedIn(fileName, sut);
        }
    }
    public class TestAnotherException : Test<Exception>
    {
        [Theory]
        [InlineAutoMoqData("borg")]
        public override void Build_ReturnsSpecificException_FileNamePassedIn(string fileName,
            ProcessFactory sut)
        {
            base.Build_ReturnsSpecificException_FileNamePassedIn(fileName, sut);
        }
    }
