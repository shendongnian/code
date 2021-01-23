    class Program
    {
        public static void Main()
        {
            int[] test = { 1, 2, 3, 4, 5 };
            int k = 4;
            WriteCombinations(test, k);
            Console.ReadLine();
        }
        static void WriteCombinations(int[] array, int k, int startPos = 0, string prefix = "")
        {
            for (int i = startPos; i < array.Length - k + 1; i++)
            {
                if (k == 1)
                {
                    Console.WriteLine("{0}, {1}", prefix, array[i]);
                }
                else
                {
                    string newPrefix = array[i].ToString();
                    if (prefix != "")
                    {
                        newPrefix = string.Format("{0}, {1}", prefix, newPrefix);
                    }
                    WriteCombinations(array, k - 1, i + 1, newPrefix);
                }
            }
        }
    }
