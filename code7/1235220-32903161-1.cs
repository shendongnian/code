	private void RadContextMenu_Opening(object sender, Telerik.Windows.RadRoutedEventArgs e)
    {
        var calendarButton = (sender as RadContextMenu).GetClickedElement<CalendarButton>();
        if (calendarButton != null && (calendarButton.ButtonType == CalendarButtonType.Date || calendarButton.ButtonType == CalendarButtonType.TodayDate))
        {
            var calendarButtonContent = calendarButton.Content as CalendarButtonContent;
            if (calendarButtonContent != null)
            {
                var clickedDate = calendarButtonContent.Date;
                radCalendar.SelectedDate = calendarButtonContent.Date;
            }
        }
        else
        {
            e.Handled = true;
        }
    }
