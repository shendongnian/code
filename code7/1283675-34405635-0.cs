            int weeks = 1;
            int days = 1;
            var Names = new[] {"Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
            string dayName;
            int commaIndex = 0;
            int date = 1;
            while (weeks < 5)
            {
                while (days < 8)
                {
                    
                    dayName = Names[days-1];
                    lblCalendar.Text += dayName + "." + " " + date + " ";
                    days++;
                    date++;
                }
                days = 1;
                weeks++;
            }
