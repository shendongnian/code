    public string RemoveStopWords(string originalDoc){
        return String.Join(" ", 
               originalDoc.Split(' ')
                  .Where(x => !stopWordsDic.ContainsKey(x))
                  .Select(x => x)
        );
    }
