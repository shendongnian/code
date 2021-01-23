    List<string> keywords1 = new List<string>() { "word1", "word2", "word3", "word4" };
    string sentence = Console.ReadLine(); //Let this be "I have word1, searching for word3"
    Console.WriteLine("Matching words:");
    bool isFound = false;
    foreach (string word in keywords1.Where(x => sentence.IndexOf(x, StringComparison.OrdinalIgnoreCase) >= 0))
    {
        Console.WriteLine(word);
        isFound = true;
    }      
    if(!isFound)
        Console.WriteLine("No Result");
