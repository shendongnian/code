    string[] playerFile = File.ReadAllLines("players.txt");
    
    foreach (string s in playerFile)
    {
        //Console.WriteLine(s);
        string[] playerStuff = s.Split(';');
        //Inner foreach that writes out each entry of the array
        foreach(var item in playerStuff)
        {
             Console.WriteLine(item);
        }
    }
    Console.ReadKey();
