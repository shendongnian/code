    public string[] Changes(string one, string two)
    {
        string[] wordsonone = one.Split(" ".ToCharArray());//Creates a string array by splitting the string into individual words.
        string[] wordsontwo = two.Split(" ".ToCharArray());
        List<string> changes = new List<string>();//Create a string list to contain all the changes.
        for(int i = 0; i < wordsonone.Length; i++)
        {
            if(!wordsontwo.Contains(wordsonone[i]))//If wordsontwo doesn't contain this word.
            {
                changes.Add(wordsonone[i]);//Add this word to changes
            }
        }
        for (int i = 0; i < wordsontwo.Length; i++)
        {
            if(!wordsonone.Contains(wordsontwo[i]))
            {
                changes.Add(wordsontwo[i]);
            }
        }
        return changes.ToArray();
    }
