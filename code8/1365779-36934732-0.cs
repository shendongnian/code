    public static class ExtMeth
    {
        public static IEnumerable<string> SkipLines(this string[] s, int number)
        {
            for (int i = number; i < s.Length; i++)
            {
                yield return s[i];
            }
        }
        public static string[] ToArray(this IEnumerable<string> source)
        {
            int count = 0;
            string[] items = null;
            foreach (string it in source)
            {
                count++;
            }
            int index = 0;
            foreach (string item in source)
            {
                if (items == null)
                {
                    items = new string[count];
                }
                items[index] = item;
                index++;
            }
            if (count == 0) return new string[0];
            return items;
        }
    }
