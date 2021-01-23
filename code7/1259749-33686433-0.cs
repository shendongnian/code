    //presumed to be your 'Entity'.
    public partial class AppDictionary
    {
        public string Language {get;set;}
        public string Text {get;set;}
    }
   
    public IEnumerable<string> GetResults(string lang)
    {
        var query = context.AppDictionaries.Where((record) => String.Compare(record.Language.ToLower(), lang.ToLower(), true) == 0);
    
        return query.AsEnumerable(); //executes and loads at this point
    }
