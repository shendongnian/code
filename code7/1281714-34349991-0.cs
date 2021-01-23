        //Here i'll get days like 0, 2, 3, 4, 6 pattern, and i'm splitting them based on comma to get single-single day value in array of string 
        string DayInWeek = "0, 2, 3, 4, 6";
        string[] GetDays = DayInWeek.Split(','); //[Here day patterns will change everytime, based on user selection]
        
        DayOfWeek nextAvailableDay;
        
        //Here i'm looping to take each day and get Enum Text based on Enum Value
        foreach (string FirstDay in GetDays)
        {
            //Here i'm converting the string value into int and passing to DayOfWeek Enum to get respective day
            DayOfWeek DayChoosen = ((DayOfWeek)(Convert.ToInt32(FirstDay)));
        
            //Here i have my actual day for example Friday
            DayOfWeek StartDay = DayOfWeek.Friday;
        
            //Here i need condition to find next available day in the foreach i.e., after Friday next value should be Saturday, or Sunday, Monday & so on until Friday==Friday
            if (StartDay.Equals(DayChoosen))
                            break;
        
            if (StartDay < DayChoosen)
            {
                nextAvailableDay = DayChoosen;
                break;
            }
            continue;
        }
