            string str = "halleluyah";
            var grouppedChars = str
                .OrderBy(c => c)
                .GroupBy(
                   c => c, 
                   c => str.Count(c2 => c2 == c)
                 );
            foreach (var group in grouppedChars)
            {
                Console.WriteLine($"{group.Key} => {group.Count()}");
            }
            Console.ReadKey();
