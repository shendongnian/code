            ButtonRow = new List<ButtonModel>();
            int daysOnButtonRow = 365;
            TimeSpan additionalDay = new System.TimeSpan(1);
            for (int i = 0; i < daysOnButtonRow; i++)
            {
                ButtonRow.Add(new ButtonModel(DaysFromToday(i),   DaysFromToday(i + 1)));
            }
