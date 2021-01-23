            int m, n, i, j;
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            int[,] v = new int[n,m];
            for (i = 0; i < n; i++)
                for (j = 0; j < m; j++)
                {
                    Console.WriteLine("v[{0}][{1}]= ", i, j);
                    v[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.WriteLine("{0} ", v[i,j]);
                Console.WriteLine();
            }
