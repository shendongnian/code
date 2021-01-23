    static void TestContains()
    {
        IList<CustomEntity> _a = new List<CustomEntity>();
        IList<CustomEntity> _b = new List<CustomEntity>();
             
        _a.Add(new CustomEntity { ID = 1, Code = "a", Description = "aaa" });
        _a.Add(new CustomEntity { ID = 2, Code = "c", Description = "c" });
    
        string name = string.Empty;
        _b = _a.Where(a => a.Description.Contains(name)).ToList();
    
        foreach (CustomEntity temp in _b)
        {
            Console.WriteLine(temp.Description);
        }
    }
