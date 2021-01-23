    static void Main(string[] args)
    {
        string word = "catt";
    
        List<string> result = new List<string>();
    
        int total = (int)Math.Pow(2, word.Length);
    
    
        for (int i = 0; i < total; i++)
        {
            string tempWord = string.Empty;
            // pick the letters from the word
    
            for (int temp = i, j = 0; temp > 0; temp = temp >> 1, j++)
            {
                if ((temp & 1) == 1)
                {
                    tempWord += word[j];
                }
            }
    
            // generate permutations from the letters
            List<string> permutations;
            Permutations(tempWord, out permutations);
    
            foreach (var prm in permutations)
                result.Add(prm);
        }
    
        // remove duplicates
        var resultWithoutDuplicates = result.Distinct();
    
        foreach (var w in resultWithoutDuplicates)
            Console.WriteLine(w);
    
    
        Console.ReadLine();
    
    }
    
    
    static void Permutations(string str, out List<string> result)
    {
        result = new List<string>();
    
        if (str.Length == 1)
        {
            result.Add(str);
            return;
        }
    
    
        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            string temp = str.Remove(i, 1);
    
            List<string> tempResult;
            Permutations(temp, out tempResult);
    
            foreach (var tempRes in tempResult)
                result.Add(c + tempRes);
        }
    }
