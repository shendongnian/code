        if (Dates[x].Year > Dates[x-1].Year) 
        {
            // current date is after previous date. List is out of order.
            return false;
        }
        if (Dates[x].Year < Dates[x-1].Year)
        {
            // current year is before previous year. This one is in order.
            continue;
        }
        if (Dates[x].Month > Dates[x-1].Month)
        {
            // Years are equal, but this date is after previous date.
            // List is out of order.
            return false;
        }
