    public class FileParser : IFileParser {
        IDelimiterProvider delimiter;
        public FileParser(IDelimiterProvider delimiter) {
            this.delimiter = delimiter;
        }
    
        public string ParseFirstRowForDelimiters(string path) {
            using (TextFieldParser parser = new TextFieldParser(path)) {
                string line = parser.ReadLine();
                return delimiter.GetDelimietr(line);
            }
        }
    }
