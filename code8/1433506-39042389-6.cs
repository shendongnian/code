    public interface ITextFieldParser : IDisposable {
        bool EndOfData { get; }
        string ReadLine();    
    }
    
    public interface ITextFieldParserFactory {
        ITextFieldParser Create(string path);
    }
