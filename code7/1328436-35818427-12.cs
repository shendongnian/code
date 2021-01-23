    public class MyDate
    {
        public int TotalDaysFrom00010101 { get; private set; }
        private const int DaysIn400YearCycle = 365 * 400 + 97;
        private const int DaysIn100YearCycleNotDivisibleBy400 = 365 * 100 + 24;
        private const int DaysIn4YearCycle = 365 * 4 + 1;
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
        private static readonly int[] DaysPerMonthLeap = new[] 
        {
            31, 
            31 + 29, 
            31 + 29 + 31, 
            31 + 29 + 31 + 30, 
            31 + 29 + 31 + 30 + 31, 
            31 + 29 + 31 + 30 + 31 + 30, 
            31 + 29 + 31 + 30 + 31 + 30 + 31, 
            31 + 29 + 31 + 30 + 31 + 30 + 31 + 31, 
            31 + 29 + 31 + 30 + 31 + 30 + 31 + 31 + 30, 
            31 + 29 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31, 
            31 + 29 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30, 
            31 + 29 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30 + 31 // Useless
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
                // Full 400 year cycles
                TotalDaysFrom00010101 += (year2 / 400) * DaysIn400YearCycle;
                year2 %= 400;
                // Remaining 100 year cycles (0...3)
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
                // Full 4 year cycles
                TotalDaysFrom00010101 += (year2 / 4) * DaysIn4YearCycle;
                year2 %= 4;
                // Remaining non-leap years
                TotalDaysFrom00010101 += year2 * 365;
            }
            // Days from the previous month
            if (month > 1)
            {
                // -2 is because -1 is for the 1 January == 0 index, plus -1 
                // because we must add only the previous full months here. 
                // So if the date is 1 March 2016, we must add the days of 
                // January + February, so month 3 becomes index 1.
                TotalDaysFrom00010101 += DaysPerMonthNonLeap[month - 2];
                if (month > 2 && IsLeap(year))
                {
                    TotalDaysFrom00010101 += 1;
                }
            }
            // Days (note that the "instant 0" in this class is day 1, so
            // we must add day - 1)
            TotalDaysFrom00010101 += day - 1;
        }
        public void GetDate(out int year, out int month, out int day)
        {
            int days = TotalDaysFrom00010101;
            // year
            {
                year = days / DaysIn400YearCycle * 400;
                days %= DaysIn400YearCycle;
                if (days >= DaysIn100YearCycleNotDivisibleBy400)
                {
                    year += 100;
                    days -= DaysIn100YearCycleNotDivisibleBy400;
                    if (days >= DaysIn100YearCycleNotDivisibleBy400)
                    {
                        year += 100;
                        days -= DaysIn100YearCycleNotDivisibleBy400;
                        if (days >= DaysIn100YearCycleNotDivisibleBy400)
                        {
                            year += 100;
                            days -= DaysIn100YearCycleNotDivisibleBy400;
                        }
                    }
                }
                year += days / DaysIn4YearCycle * 4;
                days %= DaysIn4YearCycle;
                // Special case: 31 dec of a leap year
                if (days != 1460)
                {
                    year += days / 365;
                    days %= 365;
                }
                else
                {
                    year += 3;
                    days = 365;
                }
                year++;
            }
            // month
            {
                bool isLeap = IsLeap(year);
                int[] daysPerMonth = isLeap ? DaysPerMonthLeap : DaysPerMonthNonLeap;
                for (month = 0; month < daysPerMonth.Length; month++)
                {
                    if (daysPerMonth[month] > days)
                    {
                        if (month > 0)
                        {
                            days -= daysPerMonth[month - 1];
                        }
                        break;
                    }
                }
                month++;
            }
            // day
            {
                day = days;
                day++;
            }
        }
        public void AddDays(int days)
        {
            TotalDaysFrom00010101 += days;
        }
    }
