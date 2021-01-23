    List<string> keywords1 = new List<string>() { "word1", "word2", "word3", "word1" };
    string sentence = Console.ReadLine();
    Console.WriteLine("Matching words:");
    bool isFound = false;
    foreach (string word in keywords1.Where(x=>x.Contains(sentence)))
    {
        Console.WriteLine(word);
        isFound = true;
    }      
    if(!isFound)
        Console.WriteLine("No Result");
