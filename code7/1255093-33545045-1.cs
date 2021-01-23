    var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"};
    
    bool validate = true;
    while (validate) // Loop indefinitely
    {
    	Console.Write("\nSet your date: "); // Prompt
    	string readAddMeeting = Console.ReadLine(); // Get string from user
    	
    	DateTime scheduleDate;
    	if(DateTime.TryParseExact(readAddMeeting,dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate))
    	{
    		Console.ForegroundColor = ConsoleColor.Green;
    		Console.WriteLine("Valid date");
            validate = false;
    	}
    	else
    	{
    		Console.ForegroundColor = ConsoleColor.Red;
    		Console.WriteLine("Invalid date: \"{0}\"", readAddMeeting);
    	}
    	Console.ForegroundColor = ConsoleColor.White;
    }
