    public static void Armstrong(string i)
            {
                double k=0;
                for (int j = 0; j < i.Length; j++)
                {
                    k = k + Math.Pow(Convert.ToInt16(Convert.ToString(i[j])), i.Length);
                }
    
                if (k == int.Parse(i))
                {
                    Console.WriteLine("Armstrong");
                }
    
                else
                {
                    Console.WriteLine("Not Armstrong");
                }
            }
