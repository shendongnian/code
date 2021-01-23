    var ListofInts = new List<int>();
            for (int i  = 0; i < 1001; i++)
            {
                if (i%3==0 && i%5==0)
                {
                    ListofInts.Add(i);
                    var result = ListofInts.Sum();
                    Console.Write(result + ", ");
                }
      
            }
