    public static class LinqExtensions
    {
        public static List<int> IndicesOf(this int[] array, int item)
        {
            var indices = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == item)
                    indices.Add(i);
            }
            return indices;
        }
    }
