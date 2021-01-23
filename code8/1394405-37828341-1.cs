    private void ComboBox_Selection(object Sender, SelectionChangedEventArgs e)
        {
            var cmbBox = Sender as ComboBox;
            DateTime currTime = DateTime.UtcNow;
            TimeZoneInfo tst = (TimeZoneInfo)cmbBox.SelectedItem;
            TimeZome = TimeZoneInfo.ConvertTime(currTime, TimeZoneInfo.Utc, tst).ToString("HH:mm:ss dd MMM yy");
        }
