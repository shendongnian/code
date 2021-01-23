            foreach (var x in numberList
                .GroupBy(i => i)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key))
            {
                Console.WriteLine(x.ToString());// outputs 4
            }
