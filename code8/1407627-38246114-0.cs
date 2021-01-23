    public class PdfResult : FileResult
    {
        private const String DefaultFileName = "file.pdf";
        private readonly Byte[] _byteArray;
        public PdfResult(Byte[] byteArray, String fileName = DefaultFileName)
            : base(MediaTypeNames.Application.Pdf)
        {
            _byteArray = byteArray;
            FileDownloadName = fileName;
        }
        protected override void WriteFile(HttpResponseBase response) { response.BinaryWrite(_byteArray); }
    }
