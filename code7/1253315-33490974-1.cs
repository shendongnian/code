    class Program
        {
            private static void Main()
        {
            //Format is given by 'dd-MM-yyyy'. You can change it to the one you want like 'dd/MM/yyyy' in below two lines and in 'GetTomorrowDateInStringFormat' method.
            //Then user will have to enter date in the given format
            Console.WriteLine("\nEnter Today's date to get next date (dd-MM-yyyy)");
            var date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var currentdate = new Date(date);
            Console.WriteLine("{0}", currentdate.GetDay());
            Console.WriteLine("{0}", currentdate.GetMonth());
            Console.WriteLine("{0}", currentdate.GetYear());
            Console.WriteLine("{0}", currentdate.GetTomorrowDateInStringFormat()); //Call to newly added method
            Console.ReadLine();
        }
    
        public class Date
        {
            public DateTime MyDate { get; set; }
            public string Day;
            public int Month;
            public int Year;
    
            public Date(DateTime date)
            {
                MyDate = date;
            }
            public string GetDay()
            {
                Day = MyDate.AddDays(1).ToString("dd");
                return Day;
            }
            public int GetMonth()
            {
                Month = MyDate.AddDays(1).Month;
                return Month;
            }
            public int GetYear()
            {
                Year = MyDate.AddDays(1).Year;
                return Year;
            }
            public string GetTomorrowDateInStringFormat() //Added new method to return tomorrow's date in string format
            {
                return MyDate.AddDays(1).ToString("dd-MM-yyyy");
            }
        }
