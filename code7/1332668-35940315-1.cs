    List<string> aList = new List<string>(){"My","name","is", "jeff"}; 
    List<string> itemsToRemoveList = new List<string>(){"jeff"};
    List<string> bList = aList.Where(a => !itemsToRemoveList.Contains(a)).ToList(); 
    
    foreach (string s in aList)
    {
        Console.Write(s + " "); 
    }
    Console.WriteLine();
    foreach (string s in bList)
    {
        Console.Write(s + " "); 
    }
