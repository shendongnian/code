    Dictionary<string, int> dic = new Dictionary<string, int>();
    
    List<string> mylist = new List<string>();
    string[] str = new string[5];
    int counter = 0;
    for (int i = 0; i < 5; i++)
    {
        Console.Write("Type Number:");
        string test = Console.ReadLine();
        mylist.Add(test);
        counter++;
    }
    string key = string.Join(",", mylist);
    
    Console.WriteLine(key);
    dic.Add(key, counter);
