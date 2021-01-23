    public class HtmlMinifierMiddleware {
        public HtmlMinifier(IHtmlMinifier minifier) {
            // ...
        }
        public string Minify(string content) {
            return minifier.Minify(content);
        }
        // ...
    }
