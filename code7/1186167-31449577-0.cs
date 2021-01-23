    String []numbers = Console.ReadLine().Split(' ');
                for (int i = 0; i < limit; i++)
                {
                    array1s[i] = Convert.ToInt32(numbers[i]);
                }
                foreach (int number in array1s)
                {
                    if (number == 1)
                    {
                        count++;
                    }
                }
