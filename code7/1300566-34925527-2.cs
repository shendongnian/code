            using (var sr = new StreamReader(path))
            {
                var lines = new List<int[]>();
                while(!sr.EndOfStream)
                { lines.Add(sr.ReadLine().Split(new[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray()); }
                foreach (var node in lines.SelectMany(x => x).Distinct().OrderBy(x => x))
                {
                    Console.WriteLine(node + " " + string.Join(" ", lines.Where(x => x.Skip(1).Contains(node)).Select(x => x[0]).OrderBy(x => x)));
                }
            }
