    private void updateHolidays()
    {
        List<Holiday> localHolidays = getLocalHolidays();
        List<Holiday> remoteHolidays = getRemoteHolidays();
        List<Holiday> holidayDifference = new List<Holiday>();
        foreach (Holiday holiday in remoteHolidays)``
        {
            if (localHolidays.Contains(holiday)) 
            {
                // add holiday to holidayDifference
                holidayDifference.Add(holiday);
            }
        }
        createNewHolidays(holidayDifference);
    }
