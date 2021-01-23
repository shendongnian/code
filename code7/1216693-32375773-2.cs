            List<string> list = new List<string>()
            {
                "Hello",
                "World",
                "!",
                "Hello"
            };
            bool hasDuplicates = list.Where((l, i) => list.LastIndexOf(l) != i).Any();
            Console.WriteLine(hasDuplicates);
