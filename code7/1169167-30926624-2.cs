        DateTime date1 = DateTime.Now;
        Console.WriteLine(date1.ToString());
        
        // Get date-only portion of date, without its time.
        DateTime dateOnly = date1.Date;
        // Display date using short date string.
        Console.WriteLine(dateOnly.ToString("yyyy-MM-dd"));
