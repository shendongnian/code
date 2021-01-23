    [TestClass]
    public class UnitTest1
    {
        private IProxyDir _directoryProxy;
        private IFileDir _fileProxy;
        private IFileMgr _fileMgr;
        private Sut _sut;
        public UnitTest1()
        {
            _directoryProxy = MockRepository.GenerateMock<IProxyDir>();
            _fileProxy = MockRepository.GenerateMock<IFileDir>();
            _fileMgr = MockRepository.GenerateMock<IFileMgr>();
        }
        [TestMethod]
        public void ShouldLoadFilesAndSaveInDatabase()
        {
            // Arrange
            var path = RandomGenerator.GetRandomString(56);
            var encoding = Encoding.Unicode;
            var fileNameEnvironment = RandomGenerator.GetRandomString(5);
            var fileNameModule = RandomGenerator.GetRandomString(5);
            var fileNameRecordLocator = RandomGenerator.GetRandomString(6);
            var fileNameTimestamp = RandomGenerator.GetRandomDateTime().ToString("O").Replace(':', 'o');
            // We simulate the presence of 4 files.
            var files = new List<string>
            {
                RandomGenerator.GetRandomString(255),
                RandomGenerator.GetRandomString(255),
                RandomGenerator.GetRandomString(255),
                RandomGenerator.GetRandomString(255)
            }.ToArray();
            var expectedResult = 4;
            this._directoryProxy.Expect(d => d.GetFiles(path))
                .Return(files);
            this._fileProxy.Expect(f => f.ReadAllLines(path, encoding))
        .Return(files).Repeat.Times(files.Length);
            _sut = new Sut(_directoryProxy, _fileProxy, _fileMgr);
            // Act
            var result = this._sut.LoadFilesAndSaveInDatabase(path);
            // Assert
            Assert.AreEqual(result, expectedResult);
            this._directoryProxy.AssertWasCalled(d => d.GetFiles(path));
            this._fileProxy.AssertWasCalled(f => f.ReadAllLines(path, Encoding.Unicode));
        }
    }
    internal class RandomGenerator
    {
        public static string GetRandomString(int number)
        {
            return "ssss";
        }
        public static DateTime GetRandomDateTime()
        {
            return new DateTime();
        }
    }
