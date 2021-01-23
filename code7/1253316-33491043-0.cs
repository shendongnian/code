    using System;
    using System.Globalization;
    using System.Text;
    namespace DateTester
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("\nEnter Today's date in MM/dd/yyyy to get next date ");
            
                var userDate = Console.ReadLine();
                MyDate currentdate = new MyDate(userDate);
                Console.WriteLine("{0}", currentdate.GetTomorrowDate());
                Console.ReadLine();
            }
            public class MyDate
            {
                public DateTime day;
          
                public MyDate(string inputDate)
                {
                
                    this.day = DateTime.ParseExact(inputDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
           
                public string GetTomorrowDate()
                {
                    return day.AddDays(1).ToString("dd");
                }
            }
        }
    }
