     int[] a = new int[] { 5, 1, 6, 2, 4, 3 };
                int i, j, key;
                var result = string.Empty;
                for (i = 0; i < 6; i++)
                {
                    for (j = i+1; j < 6; j++)
                    {
                        if (a[i] > a[j])
                        {
                            key = a[i];
                            a[i] = a[j];
                            a[j] = key;
                        }
                        
                    }
                    result += a[i].ToString() + ((i == 5) ? "" : ",");
                }
           
                Console.WriteLine( result);
                Console.ReadKey();
