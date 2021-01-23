                    int x = 0;
                    for (int i = 0; i < int.MaxValue; i++)
                    {
                        sum += i;
                        x = sum;
                    }
                    counter++;
                    Console.WriteLine(sw.Elapsed + "  " +  x);
