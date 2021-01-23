     public static void BubbleSort<T>(T[] array) where T : IComparable
            {
                for (int outer = array.Length; outer >= 1; outer--)
                {
                    for (int inner = 0; inner < outer - 1; inner++)
                    {
                        if (array[inner].CompareTo(array[inner + 1]) > 0)
                        {
                            T swap = array[inner];
                            array[inner] = array[inner + 1];
                            array[inner + 1] = swap;
                        }
    
                    }
                }
            }
