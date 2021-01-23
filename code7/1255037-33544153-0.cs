     public static int fact(int y)
            {
                int count = n;
                if (y <= 1)
                {
                    Console.WriteLine(y);
                    return; **// => Here your recurstion ends**
                }
                else
                {
                    count = (count * y);
                    Console.WriteLine(count);
                }
            }
