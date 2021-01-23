        private static ulong Getmultiple(ulong n)
        {
            for (ulong i = 1; ; i++)
            {
                String binary = Convert.ToString((long)i,2);
                ulong no = 0;
                if (ulong.TryParse(binary,out no))
                {
                    if (no % n == 0)
                    {
                        return no;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
