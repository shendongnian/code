    public class DefaultDelimiterLogic : IDelimiterLogic {
        public string Invoke(string line) {
            if (line.Contains("'")) {
                return "'";
            }
            if (line.Contains("\"")) {
                return "\"";
            }
            return "";
        }
    }
