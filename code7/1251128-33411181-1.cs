    public void addMeeting()
    {
        string readAddMeeting;
        var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"}; // I copied this
        bool isDateOk = false;
    
        Console.WriteLine("Add a schedule for specific dates: ");
    
        readAddMeeting = Console.ReadLine();
    
        foreach (string myDateFormat in dateFormats)
        {
            DateTime dateValue;
            if (DateTime.TryParse(readAddMeeting, dateValue)) 
            {
                isDateOk = true;
            }
        }
    
        if (isDateOk == false)
        {
            Console.Writeline("Sorry this is not a valid date");
        }
    }
