    [Route("Get")]
    public List<WordVm> Get()
    {
    
        var manager = new WordsManager()
    
       return manager.GetWords();
    }
    
  
      public class WordsManager
      {
         public List<WordVm> GetWords()
         {
           return repo.Words.Where(a => {
               var t = a.Trim().ToUpper().Substring(0, 1)[0]; 
               return t >= 'A' && t <= 'E';
              }).ToList();
         }
       }
