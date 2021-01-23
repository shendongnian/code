    // Function smallest n
     public int smallest(int a)
            {
                int temp = 0, holder = 0, k = 0;
                if (a <= 0) return 0;
                else
                {
                    for (int i = 100; i < Int16.MaxValue; i++)
                    {
                        int count = 0;
                        k = 0;
                        int[] array = new int[a];
                        for (int j = 1; j < 9; j++)
                        {
                            holder = i * j;
                            temp = holder;
                            while (temp > 0)
                            {
                                int rem = temp % 10;
                                if (rem == 2)
                                {
                                    count++;
                                    if (k < a)
                                    {
                                        array[k] = j;
                                        k++;
                                        break;
                                    }
                                }
                                temp /= 10;
                            }
                            if (count == a)
                            {
                                int countTemp = 0;
                                for (int h = 0; h < a; h++)
                                {
                                    if (h + 1 < a)
                                    {
                                        if (array[h + 1] == array[h] + 1 && array[0] == 1 && array[h] > 0)
                                        {
                                            countTemp++;
                                            if (countTemp == a - 1)
                                                return i;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return 0;
            }
