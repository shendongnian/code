       public static class ArrayLinq
        {
            public static IEnumerable<KeyValuePair<string, string>> Flatten(this string[,] map, int colcheck, int colvalue)
            {
                for (int row = 0; row < map.GetLength(0); row++)
                {
                    yield return new KeyValuePair<string, string>(map[row, colcheck], map[row, colvalue]);
                }
            }
        }
