    static void SortArray()
        {
            int[] array = { 40, 5, 6, 1, 90, 23, 5 };
            //Array.Sort(array);
            int i = 0;
            
            while (i < array.Length)
            {
                bool flag = false;
                if (i < array.Length - 1)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        //reset i
                        i = 0;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    i++;
                }
            }
            //PRINT
            for (int a = 0; a < array.Length; a++)
            {
                Console.WriteLine(array[a].ToString());
            }
        }
