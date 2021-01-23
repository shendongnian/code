        int weeklyLogic = 0;
        DateTime Firstweek = new DateTime();
        DateTime cutDayFirst = new DateTime();
        List<calculatedDays>Days=new List<calculatedDays>();
       foreach (var delivery in day)
       {
       weeklyLogic = ((int)Enum.Parse(typeof(DayOfWeek), delivery.DeliveryDay) - (int)today.DayOfWeek + 7) % 7;
         var nextweeklyLogic = today.AddDays(weeklyLogic);
         Firstweek = nextweeklyLogic;
        var cutDayLogic = nextweeklyLogic.AddDays(-delivery.CloseDayId);
        cutDayFirst = cutDayLogic;        
         
        calculatedDays d= new calculatedDays();
        d.SubRegionID=delivery.SubRegionID;
        d.Firstweekdate =Firstweek ;
        d.cutDayFirstdate =cutDayFirst ;
        Days.add(d);
      }
