     String line = "xxx/qwerty/asdfg/xxx/zxcvb";
     string[] words = line.Split('/');
      for (int i = 0; i < words.Length; i++)
       {
           if (words[i].Contains("xxx"))
            {
                    if (i == 0)
                        Console.WriteLine("No Previous Word");
                    else if (i == words.Length)
                        Console.WriteLine("No Next Word");
                    else
                    {
                        Console.WriteLine(words[i - 1]); //PreviousWord
                        Console.WriteLine(words[i + 1]); //NextWord
                    }
             }
        }
