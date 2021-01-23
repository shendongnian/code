    var results = File.ReadAllLines(@"Your file path.txt")
            .Select(record => record.Split(','))
            .Select(tokens => new { Name1 = tokens[0], Name2 = tokens[1], Name3 = tokens[2], Group1 = tokens[3], Group2 = tokens[4] })
            .GroupBy(x => new { x.Name1, x.Name2, x.Name3 }).ToList();            
            foreach(var result in results)
            {
                Console.WriteLine(result.Key.Name1);
                Console.WriteLine(result.Key.Name2);
                Console.WriteLine(result.Key.Name3);                
                foreach(var groupItem in result.ToList())
                {
                    Console.WriteLine(groupItem.Group1);
                    Console.WriteLine(groupItem.Group2);
                }
            }
