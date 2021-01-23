    List<int> list = new List<int>() { 1, 2, 5, 3, 1, 2, 3, 4, 5, 6 };
    
                var info = list.GroupBy(i => i).ToDictionary(i => i.Key, i => i.Count());
    
                foreach (var k in info.Where(k => k.Value > 1))
                    Console.WriteLine(k.Key);
