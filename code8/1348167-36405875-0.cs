    string word = "HELLO";
    string[] strIndexes = new string[] { "2", "4" };
    //
    int[] replacementPositions = Enumerable.Range(1, word.Length) // nonzero-based
        .Where(i => Array.IndexOf(strIndexes, i.ToString()) == -1)
        .ToArray();
    StringBuilder sb = new StringBuilder(word);
    for(int i = 0; i < replacementPositions.Length; i++)
        sb[replacementPositions[i] - 1] = '*';
    
    string result = sb.ToString();
