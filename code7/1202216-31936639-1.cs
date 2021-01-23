            var list = new List<string>();
            foreach (var subDirectory in Directory.EnumerateDirectories(@"C:\Temp"))
            {
                var files = Directory.EnumerateFiles(subDirectory);
                var repeated = files.Select(Path.GetFileNameWithoutExtension)
                    .GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(y => y.Key);
                list.AddRange(repeated);
            }
