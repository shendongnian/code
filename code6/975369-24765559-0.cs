    IEnumerable<int> squares =
                    Enumerable.Range(1, 10).Select(x => x * x);
    
                foreach (int num in squares)
                {
                    Console.WriteLine(num);
                }
                /*
                 This code produces the following output:
    
                 1
                 4
                 9
                 16
                 25
                 36
                 49
                 64
                 81
                 100
                */
