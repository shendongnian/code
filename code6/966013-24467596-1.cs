    var map = new Dictionary<int, List<List<int>>>();
    map[2] = new List<List<int>>();
    map[2].Add(new List<int>(){ 2, 3});
    map[2].Add(new List<int>(){ 4, 6});
    map[4] = new List<List<int>>();
    map[4].Add(new List<int>(){ 3, 5, 6});
    foreach(var key in map.Keys)
    {
        foreach(var lists in map[key])
        {
            Console.WriteLine("Key: {0}", key);
            foreach(var item in lists)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
     }
