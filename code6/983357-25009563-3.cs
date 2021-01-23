    public static class DownloadHander
        {
        private static List<IFileDownload> _handlers; 
        static DownloadHander()
        {
            _handlers = new List<IFileDownload>();
        }
        public static void Initialize()
        {
            _handlers.Add(new PDFDonwload());
        }
        public static Stream HandleDownload(string abbreviation)
        {
            foreach (var fileDownload in _handlers)
            {
                if (fileDownload.Abbreviation == abbreviation)
                {
                    //and here you make a stream for client
                }
            }
            throw new Exception("No Handler");
        }
    }
