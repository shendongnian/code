    public static class PlatypusConstsAndUtils
    {
    
        public static List<string> MonthsFull = new List<string>
        {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
        };
    
        public static int GetIndexForPreviousMonth()
        {
            // Months are 1-based, but return the index, which is 0-based, so decrement it
            const int JANUARY = 1;
            const int DECEMBER = 12;
            int prevMonth;
            int currentMonth = DateTime.Now.Month;
            if (currentMonth == JANUARY)
            {
                prevMonth = DECEMBER - 1;
            }
            else
            {
                prevMonth = DateTime.Now.Month - 2;
            }
            return prevMonth;
        }
        . . .
