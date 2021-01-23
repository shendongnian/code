    public class MeaningsCollection
    {
        public List<string> meanings {get;set;}
    
        public override string ToString()
        {
            return "the collection in your preferred format";
        }
    }
    public class ResultViewModel 
    {
         public string word {get;set;}
         public MeaningsCollection Meanings {get;set;}
    }
