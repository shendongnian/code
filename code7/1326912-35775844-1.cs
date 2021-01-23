    Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
    List<String> ls = new List<string>();
    ls.Add("item1");
    ls.Add("item2");
    dictionary.Add("it1", ls);
    dictionary.Add("it2", ls);
    foreach (var item in dictionary)
    {
        foreach(var it in item.Value)
        {
            Console.WriteLine(it);
        }
    }
