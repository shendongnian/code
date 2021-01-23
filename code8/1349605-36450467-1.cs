     static void Main(string[] args)
        {
            int monthdigit = 0;
            DateTime _date;
            
            Console.WriteLine("Enter Month");
            string monthName= Console.ReadLine(); //should be in format "Jan","Feb"
            
            if (DateTime.TryParseExact(monthName, "MMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out _date))
            {
                monthdigit = (int)_date.Month;
            }
            else
            {
                Console.WriteLine("invalid..programm will exit");
                return;
            }
            
            List<MonthInfo> GetMyDate = GetDates(2016, monthdigit);
             //stores the cursor position to align the days accordingly
            List<CursorPosition> CurorList = new List<CursorPosition>();
            CurorList.Add(new CursorPosition() { DayName = "Sun", DayWeek=DayOfWeek.Sunday });
            CurorList.Add(new CursorPosition() { DayName = "Mon", DayWeek = DayOfWeek.Monday });
            CurorList.Add(new CursorPosition() { DayName = "Tue", DayWeek = DayOfWeek.Tuesday });
            CurorList.Add(new CursorPosition() { DayName = "Wed", DayWeek = DayOfWeek.Wednesday });
            CurorList.Add(new CursorPosition() { DayName = "Thu", DayWeek = DayOfWeek.Thursday });
            CurorList.Add(new CursorPosition() { DayName = "Fri", DayWeek = DayOfWeek.Friday });
            CurorList.Add(new CursorPosition() { DayName = "Sat", DayWeek = DayOfWeek.Saturday });
           
            //print all the days name
            foreach (CursorPosition _activeCursor in CurorList)
            {
                  Console.Write("\t{0}",_activeCursor.DayName);
                  _activeCursor.locationx = Console.CursorLeft;
                  
            }
            
   
           //retreive the cursor position and display your day index by adjusting the rownumber accordingly.
            int _dayIndex = 1;
            int rownumber = 2;
            foreach (MonthInfo _month in GetMyDate)
            {
                Console.WriteLine();
               
                    int positionx = (from p in CurorList
                                     where p.DayWeek == _month.DayName
                                     select p.locationx).Single();
                   
                Console.SetCursorPosition(positionx, rownumber + 1);
                Console.Write(_dayIndex++.ToString());
                
                    if ((int)_month.DayName== 6)
                    {
                        rownumber++;
                        Console.WriteLine();
                    }
              
                
                
            }
            Console.ReadKey();
        
        }
      public static List<MonthInfo> GetDates(int year, int month)
        {
            var query=from date in  Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                      select new MonthInfo() { DayName = new DateTime(year, month, date).DayOfWeek, DayDate = new DateTime(year, month, date) };
            return query.ToList();
        }
