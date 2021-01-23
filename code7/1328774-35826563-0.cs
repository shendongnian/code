    public List<Word> GetWords(string[] words)
    {
          var results = from word in DbContext.Words.ToArray()
                            join w in words on word equals w.ToLower()
                        select word;
          
          return results.ToList();          
                               
    }
