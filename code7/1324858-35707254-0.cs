    public static void Run()
            {
                var lines = new List<string>() { 
                "Smith, 10, 5, 9",
                "Smith, 9, 5, 6",
                "Jones, 10, 5, 7",
                "Jones, 9, 6, 5"
                };
    
    
                var aList = from l in lines                        
                            select new { Name = l.Split(',')[0], Value1 = Convert.ToInt32(l.Split(',')[1]), Value2 = Convert.ToInt32(l.Split(',')[2]), Value3 = Convert.ToInt32(l.Split(',')[3]) };
    
                var vList = from a in aList
                            group a by a.Name into g
                            select new { Name = g.Key, Value1Sum = g.Sum(a => a.Value1), Value2Sum = g.Sum(a => a.Value2), Value3Sum = g.Sum(a => a.Value3) };
    
                foreach (var v in vList)
                    Console.WriteLine("{0} {1} {2} {3}", v.Name, v.Value1Sum, v.Value2Sum, v.Value3Sum);
            }
