    int[] seq = new[] { 
        2, 1, 4, 2, 1, 3, 
        0, 0, 0, 0, 0, 
        1, 5, 2, 3, 7, 
        0, 0, 0, 
        1, 2, 3, 
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    bool newGroup = false;
    Dictionary<string, List<int>> groups = new Dictionary<string, List<int>>();
    foreach (int t in seq)
    {
        if (t == 0)
        {
            if (!newGroup)
            {
                groups.Add(String.Format("Group{0}", groups.Count + 1), new List<int>());
                newGroup = true;
            }
            groups[groups.Keys.Last()].Add(t);
        }
        else
        {
            newGroup = false;
        }
    }
    groups.Keys.ToList().ForEach(k => Console.WriteLine("Key {0}: Value: {1}", k, String.Join(", ", groups[k])));
