        var inputDate = "20150606 10:12";
        DateTime date;
        if (!DateTime.TryParseExact(inputDate, "yyyyMMdd HH:mm" , CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            //datetime has invalid format
        }
        else
        {
            if(date > DateTime.Now.AddHours(24))
            {
                //show warning
            }
        } 
