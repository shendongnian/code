    String line = "qwerty/asdfg/xxx/zxcvb";
    string[] words = line.Split('/');
    for(int i=0;i<words.Length,i++)
    {
    if (words[i].Contains("xxx"))
     {
         Console.WriteLine(words[i-1] ?? "No Previous Word"); //PreviousWord
         Console.Writeline(word[i+1] ?? "No Next Word"); //NextWord
        }
    }
