    public class MyDate
    {
        public int TotalDaysFrom00010101 { get; private set; }
        private const int DaysIn400YearCycle = 365 * 400 + 97;
        private const int DaysIn100YearCycleNotDivisibleBy400 = 365 * 100 + 24;
        private static readonly int[] DaysPerMonthNonLeap = new[] 
        {
            31, 
            31 + 28, 
            31 + 28 + 31, 
            31 + 28 + 31 + 30, 
            31 + 28 + 31 + 30 + 31, 
            31 + 28 + 31 + 30 + 31 + 30, 
            31 + 28 + 31 + 30 + 31 + 30 + 31, 
            31 + 28 + 31 + 30 + 31 + 30 + 31 + 31, 
            31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30, 
            31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31, 
            31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30, 
            31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30 + 31 // Useless
        };
        public static bool IsLeap(int year)
        {
            if (year % 400 == 0) return true;
            return (year % 4 == 0) && (year % 100 != 0);
        }
        public void SetDate(int year, int month, int day)
        {
            TotalDaysFrom00010101 = 0;
            {
                int year2 = year - 1;
                TotalDaysFrom00010101 += (year2 / 400) * DaysIn400YearCycle;
                year2 %= 400;
                if (year2 >= 100)
                {
                    year2 -= 100;
                    TotalDaysFrom00010101 += DaysIn100YearCycleNotDivisibleBy400;
                    if (year2 >= 100)
                    {
                        year2 -= 100;
                        TotalDaysFrom00010101 += DaysIn100YearCycleNotDivisibleBy400;
                        if (year2 >= 100)
                        {
                            year2 -= 100;
                            TotalDaysFrom00010101 += DaysIn100YearCycleNotDivisibleBy400;
                        }
                    }
                }
                TotalDaysFrom00010101 += year2 * 365;
                int leaps = year2 / 4;
                TotalDaysFrom00010101 += leaps;
            }
            if (month > 1)
            {
                TotalDaysFrom00010101 += DaysPerMonthNonLeap[month - 2];
                
                if (month > 2 && IsLeap(year))
                {
                    TotalDaysFrom00010101 += 1;
                }
            }
            TotalDaysFrom00010101 += day - 1;
        }
        public void GetDate(out int year, out int month, out int day)
        {
            throw new NotSupportedException();
        }
        public void AddDays(int days)
        {
            TotalDaysFrom00010101 += days;
        }
    }
