                long sum;
                sum = 0;
                int count;
                count = 0;
                for (long i = 0; count <= 1000; i++)
                {
                    if (i == 1) continue;
                    bool isPrime = true;
                    for (long j = 2; j < i; j++)
                    {
                        if (i != j && i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        sum += i;
                        count++;
                    }
                }
                Console.WriteLine(string.Format("{0}", sum));
                Console.ReadLine();
