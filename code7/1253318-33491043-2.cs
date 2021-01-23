    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nEnter Today's date in dd/mm/yyyy to get next date ");
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
                this.day = DateTime.ParseExact(inputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            public string GetTomorrowDate()
            {
                return day.AddDays(1).ToString("dd/MM/yyyy");
            }
        }
    }
