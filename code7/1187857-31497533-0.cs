    public static int CountHits(int[] PCArray, int[] userArray, int attempts)    
            {    
                int hit = 0;    
                int miss = 0;     
                int hits = 0;    
    
                    for (int j = 0; j < PCArray.Length; j++)
                    {
                        if (PCArray[j] == userArray[j])
                        {
                            hit = hit + 1;
                            hits = hit;
                        }
                        else
                        {
                            miss = miss + 1;    
                        }
                    }
                Console.WriteLine("Results: {0} Hit(s), {1} Miss(es)", hit, miss);
                return hits;
