    foreach (var dateGroup in dt.AsEnumerable().GroupBy(dg => dg[7])) //this groups your entries by date
            {
                TimeSpan totalTimeForDate = new TimeSpan(0);
                var ins = dateGroup.Where(dg => dg[6].ToString() == "DutyOn").OrderBy(dg => dg[8]).ToList();//this gets your dutyins and orders by time
                var outs = dateGroup.Where(dg => dg[6].ToString() == "DutyOff").OrderBy(dg => dg[8]).ToList();//this gets your dutyoffs and orders by time
                for (int inOutCounter = 0; inOutCounter < ins.Count(); inOutCounter++)
                {
                    DateTime timeIn = DateTime.Parse(ins[inOutCounter][7].ToString() + ins[8].ToString()); //you will need to modify this to parse the date correctly, 
                    DateTime timeOut = DateTime.Parse(outs[inOutCounter][7].ToString() + outs[8].ToString()); //or change you sql query to bring back the datetime in another column and parse that
                    totalTimeForDate += timeOut.Subtract(timeIn);
                    //You will need to do some error handling in here in case there are missing entries
                    //This code assumes there is always an out time to match an in time
                }
                //here you can now access:
                var hours = totalTimeForDate.Hours;
                var minutes = totalTimeForDate.Minutes;
                var seconds = totalTimeForDate.Seconds;
            }
