        public static List<int> LongestStringIndices(this string[] strings)
        {
            int longestString = -1;
            var indices = new List<int>();
            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].Length > longestString)
                {
                    longestString = strings[i].Length;
                    // We're no longer interested in the indices of the
                    // strings we now know to be shorter
                    indices.Clear();
                    indices.Add(i);
                }
                else if (strings[i].Length == longestString)
                {
                    indices.Add(i);
                }
                // If it's less than the max length so far we ignore it
            }
            return indices;
        }
