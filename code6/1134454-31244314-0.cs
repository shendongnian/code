        int readedPages = (30 - campingDays) * regularDays;
        
        if ((campingDays == 30) || (regularDays == 0))
        {
            Console.WriteLine("never");
        }
        else
        {
            double readDuration = Math.Ceiling(bookPages / (double)readedPages);
            double years = (int)(readDuration / 12);
            double remainingMonths =(readDuration % 12);
            Console.WriteLine("{0} years {1} months", years, remainingMonths);
        }
