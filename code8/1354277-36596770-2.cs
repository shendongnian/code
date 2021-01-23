            string str = "halleluyah";
            var grouppedChars = str
                .Distinct()       // removes duplicates
                .OrderBy(c => c)  // orders them alphabetically
                .ToDictionary(    // converts to dictionary [string, int]
                    c => c,
                    c => str.Count(c2 => c2 == c));
            foreach (var group in grouppedChars)
            {
                Console.WriteLine($"{group.Key} => {group.Value}");
            }
            Console.ReadKey();
