    public sealed class AspNetWordService : IWordService {
        public string CurrentWord {
            get {
                var requestUri = Request.RequestUri.AbsoluteUri;
                var theWord = requestUri.Substring(requestUri.LastIndexOf('/'));
                return theWord;
            }
        }
    }
