    switch (i)
        {
            case 1:
                for (i = 1; i <= 10; i++)
                {
                  int Val;
                  if (Int32.TryParse(1+"*"+i+"="+i*1, out Val))
                   {
                    // TryParse returns true if the conversion succeeded.
                   }
                }
                break;
        }
        Console.ReadKey();
    }
