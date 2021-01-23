    char[] test = new Char[10];
            string val = "+3% price per day(+60% price at day 20)";
            try
            {
                for (int i = 0, j = 0; val[i] != null ; i++)
                {
                    if (Char.IsDigit(val[i]))
                    {
                        test[j++] = val[i];
                        Console.WriteLine(val[i]);
                    }
                }
            }
            catch (Exception){ }
