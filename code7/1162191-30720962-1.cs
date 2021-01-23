    private DateTime newdate = DateTime.Now;
    
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
       calctl.SelectedDate = DateTime.Now;
       calctl.DisplayMode = System.Windows.Controls.CalendarMode.Year;
    }
    private void calctl_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
    {
            if (calctl.DisplayMode == System.Windows.Controls.CalendarMode.Month)
            {
                 newdate = calctl.DisplayDate;
                 calctl.DisplayMode = System.Windows.Controls.CalendarMode.Year;
            }
    }
