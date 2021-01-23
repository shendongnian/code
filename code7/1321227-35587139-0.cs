    for (int j = 0; j < word.Length; j++)
    {
       if (guessed.Contains(word[j]))
       {
          Console.Write(word[j]);
       }
       else
       {
          Console.Write("*");
       }
    }
    
