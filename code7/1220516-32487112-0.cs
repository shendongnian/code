    static void Main(string[] args)
        {
            var nums = new[] { 1, 2, 3, 4, 5, 6 };
            var combinations = new List<int[]>();
            int[] current;
    
            foreach (int i in nums)
            {
                combinations.Add(new[] { i });
    
                foreach (int j in nums.Where(n => n != i))
                {
                    current = new[] { i, j };
                    if (!combinations.Any(c => current.Length == c.Length && current.All(n => c.Contains(n))))
                    {
                        combinations.Add(current);
                    }
    
                    foreach (int k in nums.Where(n => n != i && n != j))
                    {
                        current = new[] { i, j, k };
                        if (!combinations.Any(c => current.Length == c.Length && current.All(n => c.Contains(n))))
                        {
                            combinations.Add(current);
                        }
    
                        foreach (int l in nums.Where(n => n != i && n != j && n != k))
                        {
                            current = new[] { i, j, k, l };
                            if (!combinations.Any(c => current.Length == c.Length && current.All(n => c.Contains(n))))
                            {
                                combinations.Add(current);
                            }
                            foreach (int m in nums.Where(n => n != i && n != j && n != k && n != l))
                            {
                                current = new[] { i, j, k, l, m };
                                if (!combinations.Any(c => current.Length == c.Length && current.All(c => x.Contains(n))))
                                {
                                    combinations.Add(current);
                                }
                            }
                        }
                    }
                }
            }
    
            foreach (var c in combinations)
            {
                foreach (var num in c)
                {
                    Console.Write(num + " ");
                }
    
                Console.WriteLine();
            }
    
            Console.ReadKey();
        }
