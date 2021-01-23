    private void calctl_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
    {
        if (calctl.DisplayMode == System.Windows.Controls.CalendarMode.Month)
             calctl.DisplayMode = System.Windows.Controls.CalendarMode.Year;
    }
