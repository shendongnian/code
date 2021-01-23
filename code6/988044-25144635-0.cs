    if (nextAvailableTime != null && nextAvailableTime.StartDateTime > DateTime.Today)
      {
            //DISABLE dates prior to next available date
            DateTime dt = nextAvailableTime.StartDateTime.AddDays(-1);
            for (var i = 0; i <  DateTime.DaysInMonth(dt.Year, dt.Month ); i++) //Would like to change this to beginning of current month.
            {
                tkCalendar.SpecialDays.Add(new RadCalendarDay(tkCalendar) { Date = dt.Date.AddDays(i * -1), IsDisabled = true, IsSelectable = false });
            }
       }
