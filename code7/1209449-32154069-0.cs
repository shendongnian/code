    for (int i1 = 'A'; i1 <= 'Z'; i1++)
        {
          for (int i2 = 'A'; i2 <= 'Z'; i2++)
            {
               for (int i3 = 'A'; i3 <= 'Z'; i3++)
                  {
                     for (int i4 = 0; i4 <= 999; i4++)
                       { Console.WriteLine(new string(new Char[] { (Char)i1, (Char)i2, (Char)i3 }) + i4.ToString("000"));}
                   }
             }
        }
