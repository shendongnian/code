    public static int GetDays(DateTime start, DateTime end) {
        int newDaysDiff = ((360 * (end.Year - start.Year)) + (30 * ((end.Month - start.Month) == 0 ? 0 : (end.Month - start.Month) - 1)));
        int j = 0;
        if (start.Month == end.Month && start.Year == end.Year) {
            if (start.Day == 1 && end.Day == 31) {
                j = (end.Day - start.Day);
            }
            else {
                j = (end.Day - start.Day) + 1;
            }
        }
        else {
            if (start.Day == 1) {
                j = j + 30;
            }
            else {
                j = j + DateTime.DaysInMonth(start.Year, start.Month) - start.Day + 1;
            }
            if (end.Day == 30 || end.Day == 31) {
                j = j + 30;
            }
            else {
                j = j + end.Day;
            }
        }
        newDaysDiff = newDaysDiff + j;
        return newDaysDiff;
    }
