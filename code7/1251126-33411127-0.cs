    public void addMeeting()
    {
        var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"}; 
        Console.WriteLine("Add a schedule for specific dates: ");
        string readAddMeeting = Console.ReadLine();
        DateTime scheduleDate;
        bool validDate = DateTime.TryParseExact(
            readAddMeeting,
            dateFormats,
            DateTimeFormatInfo.InvariantInfo,
            DateTimeStyles.None, 
            out scheduleDate);
        if(validDate)
            Console.WriteLine("That's a valid schedule-date: {0}", scheduleDate.ToShortDateString());
        else
            Console.WriteLine("Not a valid date: {0}", readAddMeeting);
    }
