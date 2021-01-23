      public class CIAIAnalyser : Analyzer
    {
        public override TokenStream TokenStream(string fieldName, System.IO.TextReader reader)
        {
            StandardTokenizer tokenizer = new StandardTokenizer(Lucene.Net.Util.Version.LUCENE_29, reader);
            tokenizer.SetMaxTokenLength(255);
            TokenStream stream = new StandardFilter(tokenizer);
            stream = new LowerCaseFilter(stream);
            return new ASCIIFoldingFilter(stream);
        }
    }
