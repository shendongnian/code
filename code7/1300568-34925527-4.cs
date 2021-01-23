            string path = "c:\\temp\\test.txt";
            using (var sr = new StreamReader(path))
            {
                var lines = new List<IEnumerable<int>>();
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine().Split(new[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));
                }
                foreach (var node in lines.SelectMany(x => x).Distinct().OrderBy(x => x))
                {
                    var predecessors = lines.Where(x => x.Skip(1).Contains(node))
                        .Select(x => x.First())
                        .OrderBy(x => x);
                    Console.WriteLine(node + " " + string.Join(" ", predecessors));
                }
            }
