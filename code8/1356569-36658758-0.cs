     int len = 0;
                int count = 1;
                for (int i = 1; i < 11; i++)
                {
                    count++;
                    if (count >= len)
                    {
                        len++;
                        count = 0;
                        Console.WriteLine("");
                    }
                    Console.Write(i);
                }
