       class Helper
        {
            public string barCode;
        }
    
        class MyComparer : IEqualityComparer<Helper>
        {
            public bool Equals(Helper x, Helper y)
            {
                return x.barCode == y.barCode;
            }
    
            public int GetHashCode(Helper obj)
            {
                return obj.GetHashCode();
            }
        }
    
        class Class1
        {
            static void Main()
            {
                List<Helper> bcs1 = new List<Helper>()
                {
                    new Helper() { barCode = "0001" },
                    new Helper() { barCode = "0002" },
                    new Helper() { barCode = "0003" },
                    new Helper() { barCode = "0004" }
                };
    
                List<Helper> bcs2 = new List<Helper>()
                {
                    new Helper() { barCode = "0001" },
                    new Helper() { barCode = "0002" },
                    new Helper() { barCode = "0003" }
                };
    
                bcs1 = bcs1.Except(bcs2, new MyComparer()).ToList();
                Console.WriteLine(bcs1.Count);    
                Console.WriteLine(bcs1.First().barCode);
    
                Console.ReadKey();
            }
        }
