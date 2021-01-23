    class Program
    {
        static void Main()
        {
            string date = "1987/7/2";
            DateTime dt = Convert.ToDateTime(date);
          
            string diffDate =  MyDateTimeExtension.GetDiffDate(dt);       
            string[] words = diffDate.Split('/');
            
            if (Convert.ToInt32(words[1])== 0 && Convert.ToInt32(words[2])== 0)
            {
                Console.WriteLine("Today is your Birthday");
            }
            else
            {
                Console.WriteLine("You are " + words[0] + " Year/s " +  words[1] + " Month/s " +  words[2] + " Day/s");
            }
        }
    }
    
    public static class MyDateTimeExtension
    {
        public static string GetDiffDate(this DateTime dtt)
        {
           int intYear, intMonth, intDay;
           
            DateTime td = DateTime.Now;
            int leapYear = 0;
            for (int i = dtt.Year; i < td.Year; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    ++leapYear;
                }
            }
            
            TimeSpan timespan = td.Subtract(dtt);
            
            intDay = timespan.Days - leapYear;
            int intResult = 0;
            
            intYear = Math.DivRem(intDay, 365, out intResult);
            intMonth = Math.DivRem(intResult, 30, out intResult);
            intDay = intResult;
            
            string dateFormat= String.Format(intYear.ToString() + "/" + intMonth + "/" + intDay);   
            return dateFormat;
        }
    }
