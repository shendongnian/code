    static int SumArray(int[] array)
        {
            int product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                     product *= array[i];
                }
            }
            return product;
        }
