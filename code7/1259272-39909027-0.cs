      public static int IndexOfLongestRun(string str)
        {
            var longestRunCount = 1;
            var longestRunIndex = 0;
            var isNew = false;
            var dic = new Dictionary<int, int>();
            for (var i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    if (isNew) longestRunIndex = i;
                    longestRunCount++;
                    isNew = false;
                }
                else
                {
                    isNew = true;
                    dic.Add(longestRunIndex, longestRunCount);
                    longestRunIndex = 0;
                    longestRunCount = 1;
                }
            }
            return dic.OrderByDescending(x => x.Value).First().Key;
        }
