    static class Extensions
    {
        public static IEnumerable<int> AllIndexesOf(this string str, string value)
        {
            for (var index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index, StringComparison.Ordinal);
                if (index == -1)
                    yield break;
                yield return index;
            }
        }
    }
    ...
    var allMondayIndexes = File
                .ReadAllLines("input.txt")
                .SelectMany(s => s.AllIndexesOf("Monday"));
