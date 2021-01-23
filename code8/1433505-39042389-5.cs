    public class FileParser : IFileParser {
        IDelimiterLogic delimiterLogic;
        public FileParser(IDelimiterLogic delimiterLogic) {
            this.delimiterLogic = delimiterLogic;
        }
    
        public string ParseFirstRowForDelimiters(string path) {
            using (TextFieldParser parser = new TextFieldParser(path)) {
                string line = parser.ReadLine();
                return delimiterLogic.Invoke(line);
            }
        }
    }
