    public interface ITextFieldParser : IDisposable {
        bool EndOfData { get; }
        string ReadLine();    
    }
    
    public interface ITextFieldParserFactory {
        ITextFieldParser Create(string path);
    }
    public class TextFieldParserFactory : ITextFieldParserFactory {
        public ITextFieldParser Create(string path) {
            return new TextFieldParserWrapper(path);
        }
    }
    public class TextFieldParserWrapper : ITextFieldParser {
        TextFieldParser parser;
        internal TextFieldParserWrapper(string path) {
            parser = new TextFieldParser(path);
        }
        public bool EndOfData { get{ return parser.EndOfData; } }
        public string ReadLine() { return parser.ReadLine(); }
        public void Dispose() { parser.Dispose(); }
    }
