    private void CreateDynamicCalendar()  {  
    Calendar MonthlyCalendar = new Calendar();  
    MonthlyCalendar.Name = "MonthlyCalendar";  
    MonthlyCalendar.Width = 300;  
    MonthlyCalendar.Height = 400;  
    MonthlyCalendar.Background = Brushes.LightBlue;  
    MonthlyCalendar.DisplayMode = CalendarMode.Month;  
    MonthlyCalendar.SelectionMode = CalendarSelectionMode.MultipleRange;  
    MonthlyCalendar.DisplayDateStart = new DateTime(2010, 3, 1);  
    MonthlyCalendar.DisplayDateEnd = new DateTime(2010, 3, 31);  
    MonthlyCalendar.SelectedDates.Add(new DateTime(2010, 3, 5));  
    MonthlyCalendar.SelectedDates.Add(new DateTime(2010, 3, 15));  
    MonthlyCalendar.SelectedDates.Add(new DateTime(2010, 3, 25));  /*You Can Check all selected dates here with respect to current date*/
   
    MonthlyCalendar.FirstDayOfWeek = DayOfWeek.Monday;  
    MonthlyCalendar.IsTodayHighlighted = true;  
   
    LayoutRoot.Children.Add(MonthlyCalendar);  }   
