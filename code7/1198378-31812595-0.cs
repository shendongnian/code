    public class EncodedHtml
    {
        public string Html {get; private set;}
        
        public EncodedHtml(string htmlToEncode){
            Html = EncodeHtml(htmlToEncode);
        }
    
        private string EncodeHtml(string htmlToEncode){
            // code 
            return htmlEncoded;
        }
    }
