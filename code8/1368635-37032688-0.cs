    var printNumbers = new Dictionary<int, int> { { 1, 1 }, { 2, 1 },{ 3, 1 },{ 4, 1 },{ 5, 3 }, { 6, 2 }, { 7, 1 }, { 8, 1 }, { 9, 2 } };
            foreach (var num in printNumbers)
            {
                for (int i = 0; i < num.Value; i++)
                {
                    Console.WriteLine(num.Key);
                }
            }
