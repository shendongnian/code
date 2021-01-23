     String line = "xxx/qwerty/asdfg/xxx/zxcvb";
     string[] words = line.Split('/');
      for (int i = 0; i < words.Length; i++)
       {
           if (words[i].Contains("xxx"))
            {
                    Console.WriteLine(words[i]); //current word
                    if (i == 0)
                        Console.WriteLine("No Previous Word");
                    else
                        Console.WriteLine(words[i - 1]); //PreviousWord
                    if (i == words.Length - 1)
                        Console.WriteLine("No Next Word");
                    else                                           
                        Console.WriteLine(words[i + 1]); //NextWord
             }
        }
