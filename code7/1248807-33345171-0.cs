     List<int> li = new List<int>();
            for (int i = 1; i <= 1000; i++) 
            {
                if (i%3 == 0 && i%5 == 0) 
                {
                    li.Add(i);
                }
            }
            Console.Write("sum is " + li.Sum());
            Console.ReadLine();
