    DateTime startDate = new DateTime(2011,3,1);
    DateTime endDate = DateTime.Now;
    TimeSpan diff = endDate - startDate;
    int days = diff.Days;
    for (var i = 0; i <= days; i++)
    {
        var testDate = startDate.AddDays(i);
        switch (testDate.DayOfWeek)
        {
            case DayOfWeek.Saturday:
            case DayOfWeek.Sunday:
                Console.WriteLine(testDate.ToShortDateString());
                break;
        }
    }
