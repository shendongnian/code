    String line = "qwerty/asdfg/xxx/zxcvb";
    
    string[] words = line.Split('/');
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].Contains("xxx"))
        {
            if (i - 1 > 0)
            {
                // Previous word
                Console.WriteLine(words[i - 1]);
            }
    
            if (i + 1 < words.Length)
            {
                // Next word
                Console.WriteLine(words[i + 1]);
            }
        }
    }
    
    Console.ReadLine();
