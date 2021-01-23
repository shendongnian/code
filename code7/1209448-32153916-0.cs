    for (int i1 = 'A'; i1 <= 'Z'; i1++)
    {
        for (int i2 = 'A'; i2 <= 'Z'; i2++)
        {
            for (int i3 = 'A'; i3 <= 'Z'; i3++)
            {
                for (int i4 = '0'; i4 <= '9'; i4++)
                {
                    for (int i5 = '0'; i5 <= '9'; i5++)
                    {
                        for (int i6 = '0'; i6 <= '9'; i6++)
                        {
                            Console.WriteLine(new string(new Char[] { (Char)i1, (Char)i2, (Char)i3, (Char)i4, (Char)i5, (Char)i6 }));
                        }
                    }
                }
            }
        }
    }
