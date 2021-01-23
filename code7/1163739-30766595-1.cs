    string line = "qwerty/asdfg/xxx/zxcvb";
    string[] words = line.Split('/');
    string previousWord = "";
    foreach (string word in words)
    {
        if (word.Contains("xxx"))
        {
            Console.WriteLine(previousWord);
        }
        previousWord = word;
    }
