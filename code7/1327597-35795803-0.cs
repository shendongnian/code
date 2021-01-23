      TimeZoneInfo timeZoneInfo;
            DateTime dateTime;
            //Set the time zone information to Australia Standard Time 
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Cen. Australia Standard Time");
            //Get date and time in Australia Standard Time 
            dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            //Print out the date and time
            Console.WriteLine(dateTime.ToString("dd-MM-yyyy HH:mm:ss"));
