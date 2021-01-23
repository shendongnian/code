    public static class SelectionSort
    {
        static int min;
        public static void Sort(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    min = j;
                    if (data[i] < data[j])
                        Swap(x: ref data[i], y: ref data[min]);
                }
            }
        }
    
        private static void Swap(ref int x, ref int y)
        {
            x = x + y;
            y = x - y;
            x = x - y;
        }
    }
