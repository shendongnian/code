    public class Generator
    {
        public void gen()
        {
            for (int a = 0; a < 100; a++)
            {
                for (int divident = 1; divident <= 50; divident++)
                {
                    int div = a / divident;
                    if ((div % 1) == 0)
                    {
                        Console.WriteLine(a);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
