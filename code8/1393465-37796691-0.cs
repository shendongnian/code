    Dictionary<int, int> dic = new Dictionary<int, int>() { { 1, 2 }, { 2, 3 }, { 3, 2 } };
    foreach (int value  in dic.Values)
        Debug.WriteLine(value);
    foreach (int key in dic.Keys.ToList())
        dic[key] = 12;
    foreach (int value in dic.Values)
        Debug.WriteLine(value);
    Debug.WriteLine("done");
