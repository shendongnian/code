    public class ShuffledRow
    {
        public static readonly Random Random = new Random();
        public readonly int[] Row;
        /// <summary>
        /// Generates and shuffles some numbers
        /// from min to max-1
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max">Max is excluded</param>
        public ShuffledRow(int min, int max)
        {
            int count = max - min;
            Row = Enumerable.Range(min, count).ToArray();
            Shuffle(Row);
        }
        private static void Shuffle<T>(T[] array)
        {
            // Fisher-Yates correct shuffling
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Random.Next(i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
