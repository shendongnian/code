    string str = "1 0 3; 2 0 3; 3 0 3";
    string[] split = str.Split(';');
    foreach (string s in split)
    {
        Console.WriteLine(s);
    }
