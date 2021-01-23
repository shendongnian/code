     List<YearClass> months = new List<YearClass>();
                int thisMonthsDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
    
                for (int i = 1; i <= thisMonthsDays; i++)
                {
                    YearClass currentDay = new YearClass();
                        currentDay.IndexOfMonth = i;
                        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i);
                        currentDay.DayName = dt.DayOfWeek.ToString();
                        months.Add(currentDay);
                }
    
                comboBox1.DataSource = months;
                comboBox1.DisplayMember = "DayName";
