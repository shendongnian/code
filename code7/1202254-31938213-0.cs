              int countWorkingDays= 0;
              string startdate1 = "2014/04/28";
              string  enddate1 ="2014/09/12";
    
                DateTime startdate= DateTime.ParseExact(startdate1, "yyyy/MM/dd",System.Globalization.CultureInfo.InvariantCulture);
                DateTime enddate= DateTime.ParseExact(enddate1, "yyyy/MM/dd",System.Globalization.CultureInfo.InvariantCulture);
                DateTime date =startdate;
                while (date<= enddate)
    	        {
                    if (!(date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday))
                    {
                        countWorkingDays++;
                    }
                    date= date.AddDays(1);  
    	        }
                Console.WriteLine("WorkingDays " +countWorkingDays);
