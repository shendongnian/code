    public interface IFileDownload
    {
        string Abbreviation { get; }
    }
    public class PDFDonwload : IFileDownload
    {
        public string Abbreviation { get; private set; }
    }
