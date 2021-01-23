    String line = "qwerty/asdfg/xxx/zxcvb";
    
    string[] words = line.Split('/');
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].Contains("xxx"))
        {
            // Check to make sure you to go beyond the first element
            if (i - 1 > -1)
            {
                // Previous word
                Console.WriteLine(words[i - 1]);
            }
            // Check to make sure you to go beyond the last element    
            if (i + 1 < words.Length)
            {
                // Next word
                Console.WriteLine(words[i + 1]);
            }
        }
    }
    
    Console.ReadLine();
