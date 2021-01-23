     class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 1, 5, 4, 3, 1, 6, 5 };
            RemoveRepeated(ref arr);
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        private static void RemoveRepeated(ref int[] array)
        {
            int count =0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        int temp = array[j];
                        count++;
                        for (int k = j; k < array.Length-1; k++)
                        {
                            array[k] = array[k + 1];
                        }
                        array[array.Length - 1] = temp;
                        j = array.Length;
                    }
                }
            }
            Array.Resize(ref array, array.Length - count);
        }
    }
