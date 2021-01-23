    var selectedDates = new List<DateTime?>();
    DateTime? StartDate = DateTime.Parse("01/04/2016 00:00:00");
    DateTime? EndDate = DateTime.Parse("10/04/2016 00:00:00");
    
    do
    {
        selectedDates.Add(StartDate);
        StartDate = StartDate.Value.AddDays(1);
    }while(StartDate < EndDate);
