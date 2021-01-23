        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 4, 5 };
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count = i + count;
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
