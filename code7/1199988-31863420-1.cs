    var characterCount= new Dictionary<char,int>();
    foreach(var c in sign)
    {
        if(characterCount.ContainsKey(c))
            characterCount[c]++;
        else
            characterCount[c] = 1;
    }
