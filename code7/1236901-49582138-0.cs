            var patterns = new[] { "dog", "cat", "cats and dogs", "parrot", "parrot and cat" };
            foreach (var item in patterns)
            {
                switch (item)
                {
                    case var s when s.Contains("cat"):
                        Console.WriteLine($"{item} contains cat");
                        break;
                    case var s when s.Contains("dog"):
                        Console.WriteLine($"{item} contains dog");
                        break;
                    case var s when s.Contains("parrot"):
                        Console.WriteLine($"{item} contains parrot");
                        break;
                }
            }
