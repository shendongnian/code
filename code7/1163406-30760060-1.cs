    //assuming firstDate & lastDate have date and time
            int[] weekendDays = new int[2] { 0, 6 }; // Sunday and Saturday
            GetProperOfficeHours(ref firstDate);
            GetProperOfficeHours(ref lastDate);
            while (weekendDays.Contains((int)firstDate.DayOfWeek))
            {
                //get next date
                firstDate = firstDate.AddDays(1);
            }
            while (weekendDays.Contains((int)lastDate.DayOfWeek))
            {
                //get prev date
                lastDate = lastDate.AddDays(-1);
            }
            double hourDiff = Math.Abs(firstDate.Hour - lastDate.Hour) / 8.0; //8 office hours
            double dayDifference = 0;
            while (firstDate.Date <= lastDate.Date) //Loop and skip weekends
            {
                if (!weekendDays.Contains((int)firstDate.DayOfWeek)) //can also check for holidays here
                    dayDifference++;
                firstDate = firstDate.AddDays(1);
            }
            dayDifference = dayDifference + hourDiff;
