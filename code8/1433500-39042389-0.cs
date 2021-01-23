    public class DefaultDelimiter : IDelimiterProvider {
        public string GetDelimiter(string line) {
            if (line.Contains("'")) {
                return "'";
            }
            if (line.Contains("\"")) {
                return "\"";
            }
            return "";
        }
    }
