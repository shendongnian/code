    //try this...
            if (!e.Day.IsOtherMonth)
            {        
                if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday && e.Day.Date.Day > 7 && e.Day.Date.Day < 15)
                {
                    e.Cell.ForeColor = System.Drawing.Color.Red;
                    e.Cell.ToolTip = "Second Saturday";
                }
            }
