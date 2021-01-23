    bool isFree = false;
    List<Calendar> calendarItems = calendar.Where(m => m.Id == Supplier.Id && m.StartTime.Date == customerAvailableStart.Date).OrderBy(m => m.StartTime).ToList();
    if (calendarItems .Count > 0)
    {
        DateTime date1, date2;
        date1 = customerAvailableStart;
        for (var i = 0; i <= calendarItems .Count; i++)
        {
            if (i != calendarItems .Count)
            {
                date2 = calendarItems [i].StartTime;
            }
            else
            {
                date2 = customerAvailableEnd;
            }
            if (date2.Subtract(date1).TotalHours >= packageTime)
            {
                date1Free = true;
                break;
            }
            date1 = calendarItems [i].EndTime;
        }
    }
