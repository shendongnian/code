    private string[] GetWords(string path, int step){
        var words = File.ReadAllText(path).Split(' ', StringSplitOptions.RemoveEmpyEntries);
        var resultList = new List<string>(words.Length/step);
        for(var i=0; i<words.Length; i+=step)
        {
           var word = words[i];
           resultList.Add(word);
        }
        return resultList.ToArray();
    }
