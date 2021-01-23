    public class HtmlMinifier {
        public HtmlMinifier(IHtmlMinifier minifier) {
            
        }
        public string Minify(string content) {
            return minifier.Minify(content);
        }
    }
