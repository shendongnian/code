     //try this....
            if (!e.Day.IsOtherMonth)//check whether the day is in selected month or not
            {               
                // 2nd Saturday must be before the 15th day and after 7th of the month...,so check the condition
                if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday && e.Day.Date.Day > 7 && e.Day.Date.Day < 15)
                {
                    e.Cell.ForeColor = System.Drawing.Color.Red;//set the Day in Red colour
                    e.Cell.ToolTip = "Second Saturday";//set the tooltip as 'Second saturday'
                }
            }
