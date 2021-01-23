    var today = DateTime.Today;
    var temp = new { DeliveryDay = "Friday" };
    var weekly = GetPeriodicDeliveryDates(today, Enum.Parse(typeof(DayOfWeek), temp.DeliveryDay), 7);
    var fortnightly = GetPeriodicDeliveryDates(today, Enum.Parse(typeof(DayOfWeek), temp.DeliveryDay), 14);
    weekly.Take(5).ToList().ForEach(x => Console.WriteLine(x));
    Console.WriteLine();
    fortnightly.Take(5).ToList().ForEach(x => Console.WriteLine(x));
