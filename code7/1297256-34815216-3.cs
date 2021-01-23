     Dictionary<Char,int> alphabets = new Dictionary<Char,int>();
    for (int i = 0; i < input.Length; i++)
    {
        char character= input[i];
        if(Char.IsLetter(character)) // this is important user can enter numbers as well
        {
            if(alphabets.ContainsKey(character)) // if letter already in increment count
                    alphabets[character] = alphabets[character] + 1;
            else
                   alphabets.Add(character,1); // else add in dictionary 
        } 
    }
    
