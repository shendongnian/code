       //Example List containing the time values
            List<string> dates = new List<string>();
            dates.Add("00:00:01");
            dates.Add("00:00:02");
            dates.Add("00:00:03");
            dates.Add("00:00:09");
            dates.Add("00:00:05");
            dates.Add("00:00:07");
            //The time value selected in the listview
            long SelectedDate = DateTime.Parse("00:00:04").Ticks;
            //By converting the values to Long, we can get the closest value using Math.Abs.
            string closest = dates.Aggregate((x, y) => Math.Abs(DateTime.Parse(x).Ticks - SelectedDate) < Math.Abs(DateTime.Parse(y).Ticks - SelectedDate) ? x : y);
