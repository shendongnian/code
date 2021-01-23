    [TestClass]
    public class GlobalTestData
    {
        private static byte[] _document;
        public static byte[] Document
        {
            get
            {
                return (byte[])_document.Clone();
            }
        }
        [AssemblyInitialize()]
        public static void DownloadDocument(TestContext context)
        {
            _document = DownloadDocument();
        }
        private static byte[] DownloadDocument()
        {
            //...
        }
    }
