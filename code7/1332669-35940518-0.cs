        List<string> aList = new List<string>() { "My", "name", "is", "jeff" }; // cached full list
        List<string> bList = new List<string>();
        foreach(var item in aList)
        {
            bList.add(item);
        }
        List<string> itemsToRemoveList = new List<string>() { "jeff" };
        bList.RemoveAll(itemsToRemoveList.Contains); // remove only from copy
        foreach (string s in aList)
        {
            Console.Write(s + " "); // expect "my name is jeff"
        }
            Console.WriteLine();
        foreach (string s in bList)
        {
            Console.Write(s + " "); // expect "my name is"
        }
        // however this modifies both collections. 
        Console.ReadLine();
