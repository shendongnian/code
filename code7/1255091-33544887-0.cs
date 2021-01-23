    do{
    var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"};
    Console.Write("\nSet your date: ");
    string readAddMeeting = Console.ReadLine();
    DateTime scheduleDate;
    bool validDate = DateTime.TryParseExact(
    readAddMeeting,
    dateFormats,
    DateTimeFormatInfo.InvariantInfo,
    DateTimeStyles.None,
    out scheduleDate);
    if (validDate)
    {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Valid date");
    Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Invalid date: \"{0}\"", readAddMeeting);
    Console.ForegroundColor = ConsoleColor.White;
    }
    }while(!validDate)
