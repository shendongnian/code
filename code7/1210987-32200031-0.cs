    static void Bouns()
        {
       
            int []ar=new int[1000];
                int sum = 0;
                for (int counter = 1; counter < ar.Length; counter++)
                {
                    sum += ar[counter];
                    if (sum >= 500)
                    {
                        break;
                    }
                    Console.WriteLine(ar[counter]);
                }
	            
        }
