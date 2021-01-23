            List<string> lines = Enumerable.Range(0, 100).Select(i => i.ToString()).ToList();
            IEnumerable<string> group;
            int c = 0;
            do
            {
                group = lines.Skip(3+7*c).Take(3);
                foreach (var s in group)
                {
                    Console.WriteLine(s);
                }
                c++;
            } while (group.Count() == 3);
