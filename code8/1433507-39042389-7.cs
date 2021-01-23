    public class FileParser : IFileParser {
        IDelimiterLogic delimiterLogic;
        ITextFieldParserFactory parserFactory;
        public FileParser(IDelimiterLogic delimiterLogic, ITextFieldParserFactory parserFactory) {
            this.delimiterLogic = delimiterLogic;
            this.parserFactory = parserFactory;
        }
    
        public string ParseFirstRowForDelimiters(string path) {
            using (ITextFieldParser parser = parserFactory.Create(path)) {
                string line = parser.ReadLine();
                return delimiterLogic.Invoke(line);
            }
        }
    }
