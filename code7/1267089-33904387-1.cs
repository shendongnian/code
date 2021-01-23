    string[] lines = File.ReadAllLines("FilePath");
            foreach (var line in lines)
            {
                var firstValue = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(firstValue[1]); // Needs to have [1] or it will just print System.String[]
            }
