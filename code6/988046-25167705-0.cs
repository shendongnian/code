      if (nextAvailableTime != null && nextAvailableTime.StartDateTime > DateTime.Today)
            {
           //DISABLE dates prior to next available date
               DateTime dt = nextAvailableTime.StartDateTime.AddDays(-1);
               DateTime nextDate = nextAvailableTime.StartDateTime;
            //Gate the calendar to just go get teh product's next available date and then get block out everything until the beginning of the current month.
                var now = DateTime.Now;
                var startOfMonth = new DateTime(now.Year, now.Month, 1).DayOfYear;
             //int currentDate = DateTime.Now.DayOfYear;
                int futureDate = nextDate.DayOfYear;
               int daysBetween = (futureDate - startOfMonth);
               //  for (var i = 0; i < 31; i++)//Original from 31 days from next available.
                for (var i = 0; i < daysBetween; i++) //Get difference between next available and beginning of current month.
                    {
                       tkCalendar.SpecialDays.Add(new RadCalendarDay(tkCalendar) { Date = dt.Date.AddDays(i * -1), IsDisabled = true, IsSelectable = false });
                    }
            }
