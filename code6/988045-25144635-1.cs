    if (nextAvailableTime != null && nextAvailableTime.StartDateTime > DateTime.Today)
      {
            //DISABLE dates prior to next available date
            DateTime currentDate = DateTime.Now;
            DateTime futureDate = DateTime.Now.AddMonths(3);
            int daysBetween = (futureDate - currentDate).Days;
            for (var i = 0; i <  daysBetween; i++) 
            {
                tkCalendar.SpecialDays.Add(new RadCalendarDay(tkCalendar) { Date =  currentDate.AddDays(i), IsDisabled = true, IsSelectable = false });
            }
       }
