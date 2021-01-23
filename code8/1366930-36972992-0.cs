    class ConsoleApp
    {
        public void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            string formattedDate = GetDateString(month, day);
            Console.WriteLine(formattedDate);
            // You cannot initialize a DateTime struct only with month and day.
            // Because Year is not relevant we use the current year.
            DateTime date = new DateTime(DateTime.Now.Year, month, day);
            DateTime otherDate = date.AddDays(5);
            Console.WriteLine(GetFormattedDate(otherDate));
        }
        public static string GetFormattedDate(DateTime date)
        {
            // The ToString() method accepts any custom date format string.
            // Here is how you can create a custom date format string:
            // https://msdn.microsoft.com/en-us/library/8kb3ddd4%28v=vs.110%29.aspx
            // dd: days in two digits
            // MM: months in two digits
            return date.ToString("dd.MM");
        }
        public static string GetDateString(int month, int day)
        {
            // Here we construct a DateTime struct
            DateTime date = new DateTime(DateTime.Now.Year, month, day);
            // Now we extract only the day and month parts.
            return GetFormattedDate(date);
        }
    }
