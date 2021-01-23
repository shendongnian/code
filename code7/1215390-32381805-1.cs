     [HttpPost] // <--- remove if not using Api
     public string CheckForBadWords(string str)
     {
         string badWords = string.Empty;
         var badWordsResult = Global.CheckForBadWords(str);
         if (badWordsResult.Length > 0)
         {
             badWords = string.Join(", ", badWordsResult);
         }
    
         return badWords;
     }
