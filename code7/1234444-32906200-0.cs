        static void Main(string[] args)
        {
            TimeSpan result = new TimeSpan();
            DateTime dt1 = new DateTime(2015, 09, 29, 10, 11, 03);
            DateTime dt2 = new DateTime(2015, 10, 01, 02, 19, 38);
            DateTime d1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, 0, 0, 0); //Date only
            DateTime d2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, 0, 0, 0); //Date only
            if (DateTime.Compare(dt1, d1.AddHours(6)) > 0)
            {
                result += new TimeSpan(6, 0, 0);
                if (DateTime.Compare(dt1, d1.AddHours(23)) > 0)
                {
                    result += new TimeSpan(dt1.Hour - 23, dt1.Minute, dt1.Second);
                }
            }
            else
            {
                result += new TimeSpan(dt1.Hour, dt1.Minute, dt1.Second);
            }
            if (DateTime.Compare(dt2, d2.AddHours(6)) > 0)
            {
                result += new TimeSpan(6, 0, 0);
                if (DateTime.Compare(dt2, d2.AddHours(23)) > 0)
                {
                    result += new TimeSpan(dt2.Hour - 23, dt2.Minute, dt2.Second);
                }
            }
            else
            {
                result += new TimeSpan(dt2.Hour, dt2.Minute, dt2.Second);
            }
            int daysBetween = (int)(d2 - d1).TotalDays - 1;
            result += new TimeSpan(daysBetween * 7, 0, 0);
            
            Console.WriteLine("Night time: " + result);
            Console.ReadKey();
        }
