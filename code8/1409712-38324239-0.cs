    var timeIn = new DateTime(2016, 7, 25, 14, 0, 0);
            var timeOut = new DateTime(2016, 7, 26, 5, 0, 0);
            if ((timeOut.Date - timeIn.Date).TotalDays >= 1)
            {
                var hrs12to4am = Enumerable.Range(0, (int)(timeOut - timeIn).TotalHours + 1)
                    .Select(i => timeIn.AddHours(i)).Where(a => a.Hour < 4 && a.Date > timeIn).ToList();
                var hrsOverTen = Enumerable.Range(0, (int)(timeOut - timeIn).TotalHours + 1)
                    .Select(i => timeIn.AddHours(i)).Where(a => a.Hour > 22).ToList();
                
            }
            else
            {
                var hrsOverTen = Enumerable.Range(0, (int)(timeOut - timeIn).TotalHours + 1)
                    .Select(i => timeIn.AddHours(i)).Where(a => a.Hour > 22).ToList();
            }
