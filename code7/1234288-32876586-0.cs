    public static class LongExtensions
        {
            public static int SplitInIrregularParts(this long longNumber, int partIndexToReturn)
            {
                int[] blocks = string.Format("{0:##### #### # #}", longNumber).Split(' ').Select(x => int.Parse(x)).ToArray();
                return blocks[partIndexToReturn];
            }
        }
