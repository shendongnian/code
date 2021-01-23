        public static DateTime AddDaysWithoutLeapYear(this DateTime input, int days)
        {
            var output = input;
            
            if (days != 0)
            {
                var increment = days > 0 ? 1 : -1; //this will be used to increment or decrement the date.
                var daysAbs = Math.Abs(days); //get the absolute value of days to add
                var daysAdded = 0; // save the number of days added here
                while (daysAdded < daysAbs) 
                {
                    output = output.AddDays(increment);
                    if (!(output.Month == 2 && output.Day == 29)) //don't increment the days added if it is a leap year day
                    {
                        daysAdded++;
                    }
                }
            }
            return output;
        }
