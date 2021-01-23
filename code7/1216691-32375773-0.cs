            List<string> list = new List<string>()
            {
                "Hello",
                "World",
                "!",
                "Hello"
            };
            bool hasDuplicates = list.Any(l => list.Count(z => z == l) > 1);
            Console.WriteLine(hasDuplicates);
