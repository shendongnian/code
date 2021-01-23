    public class LogicalSorter : IComparer
    {
        public int Compare(object a, object b)
        {
            var first = Regex.Split((string)a, "([0-9]+)").Where(s => s != "").ToArray();
            var second = Regex.Split((string)b, "([0-9]+)").Where(s => s != "").ToArray();
            var endIdx = Math.Min(first.Count(), second.Count());
            for (var i = 0; i < endIdx; i++)
            {
                var part1 = first.ElementAt(i);
                var part2 = second.ElementAt(i);
                if (part1.All(char.IsDigit) && part2.All(char.IsDigit) && part1 != part2)
                {
                    return int.Parse(part1).CompareTo(int.Parse(part2));
                }
                if (part1 != part2) return part1.CompareTo(part2);
            }
            return first.Count().CompareTo(second.Count());
        }
    }
