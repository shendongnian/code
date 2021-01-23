            List<List<string>> table = new List<List<string>>();
            table.Add(new List<string>() { "a1", "b1", "c1", "d1", "e1" });
            table.Add(new List<string>() { "a2", "b2", "c2", "d2", "e2" });
            table.Add(new List<string>() { "a3", "b3", "c3", "d3", "e3" });
            List<int> indexes = new List<int>() { 1, 3, 4 };
            for (int index = 0; index < table.Count; index++)
            {
                foreach (var columnIndex in indexes)
                    Console.Write(table[index][columnIndex] +" ");
                
                Console.WriteLine();
            }
            Console.ReadLine();
