    class Group<T> : List<T>, IGrouping<T, T>
    {
        public T Key { get; private set; }
        public Group(T key)
        {
            Key = key;
        }
    }
    static class Extensions
    {
        public static IEnumerable<IGrouping<string, string>> GroupByComboboxName(this IEnumerable<string> lines)
        {
            Group<string> group = null;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(' ');
                if (parts.Length == 3 && parts[0] == "ComboBox" && parts[1] == "Name")
                {
                    if (group != null) yield return group;
                    group = new Group<string>(parts[2]);
                }
                else if (group != null)
                {
                    group.Add(line);
                }
            }
            if (group != null) yield return group;
        } 
    }
