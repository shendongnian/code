    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Give me an integer between 1 and 12, and I will give you the month");
            int monthInteger = int.Parse(Console.ReadLine()); // WARNING: throws exception for non-integer input
            Console.WriteLine(GetMonthName(monthInteger));
            Console.WriteLine();
            Console.Write("Display days in month (y/n)? ");
            if (Console.ReadLine() == "y")
            {
                int daysInMonth = GetDaysInMonth_NoLeapYear(monthInteger);
                if (daysInMonth > 0)
                {
                    Console.WriteLine(String.Format("{0} days in {1}",
                        daysInMonth.ToString(),
                        GetMonthName(monthInteger)));
                }
                else
                {
                    Console.WriteLine("Invalid month entered.");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Hit enter to close");
            Console.ReadLine();
        }
        private static String GetMonthName(int monthInteger)
        {
            DateTime newDate = new DateTime(DateTime.Now.Year, monthInteger, 1);
            String monthName = newDate.ToString("MMMM");
            return monthName;
        }
        /// <summary>
        /// Prints days in month. Assumes no leap year (since no year context provided) so Feb is always 28 days.
        /// </summary>
        /// <param name="monthInteger"></param>
        private static int GetDaysInMonth_NoLeapYear(int monthInteger)
        {
            int daysInMonth = -1; // -1 indicates unknown / bad value
            switch (monthInteger)
            {
                case 1: // jan
                    daysInMonth = 30;
                    break;
                case 2: // feb
                    daysInMonth = 28; // if leap year it would be 29, but no way of indicating leap year per problem constraints
                    break;
                case 3: // mar
                    daysInMonth = 31;
                    break;
                case 4: // apr
                    daysInMonth = 30;
                    break;
                case 5: // may
                    daysInMonth = 31;
                    break;
                case 6: // jun
                    daysInMonth = 30;
                    break;
                case 7: // jul
                    daysInMonth = 31;
                    break;
                case 8: // aug
                    daysInMonth = 31;
                    break;
                case 9: // sep
                    daysInMonth = 30;
                    break;
                case 10: // oct
                    daysInMonth = 31;
                    break;
                case 11: // nov
                    daysInMonth = 30;
                    break;
                case 12: // dec
                    daysInMonth = 31;
                    break;
            }
            return daysInMonth;
        }
        /// <summary>
        /// Prints days in month. Assumes no leap year (since no year context provided) so Feb is always 28 days.
        /// </summary>
        /// <param name="monthInteger"></param>
        private static int GetDaysInMonth_NoLeapYear_Compact(int monthInteger)
        {
            // uses case statement fall-through to avoid repeating yourself
            int daysInMonth = -1; // -1 indicates unknown / bad value
            switch (monthInteger)
            {
                case 2: // feb
                    daysInMonth = 28; // if leap year it would be 29, but no way of indicating leap year per problem constraints
                    break;
                case 3: // mar
                case 5: // may
                case 7: // jul
                case 8: // aug
                case 10: // oct
                case 12: // dec
                    daysInMonth = 31;
                    break;
                case 1: // jan
                case 4: // apr
                case 6: // jun
                case 9: // sep
                case 11: // nov
                    daysInMonth = 30;
                    break;
            }
            return daysInMonth;
        }
    }
