         int weeklyLogic = 0;
         DateTime Firstweek = new DateTime();
         DateTime cutDayFirst = new DateTime();
        foreach (var delivery in day)
        {
          weeklyLogic = ((int)Enum.Parse(typeof(DayOfWeek), delivery.DeliveryDay) - (int)today.DayOfWeek + 7) % 7;
          var nextweeklyLogic = today.AddDays(weeklyLogic);
          //initiated for all further processing by last value of day 
          Firstweek = nextweeklyLogic;
         //initiated for all further processing by last value of day
          var cutDayLogic = nextweeklyLogic.AddDays(-delivery.CloseDayId);
          cutDayFirst = cutDayLogic;                 
 
        }
