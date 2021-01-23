    private void buttonSetSystemDatetime_Click(object sender, RoutedEventArgs e)
            {
                DateTimeOffset dto = datePicker1.Date+ timePicker1.Time;
                Windows.System.DateTimeSettings.SetSystemDateTime(dto);
            }
