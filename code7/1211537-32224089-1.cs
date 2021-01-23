        public MainWindow()
        {
            InitializeComponent();
            dpFrom.DisplayDateStart = DateTime.Now - TimeSpan.FromDays(500); ;
            dpFrom.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(500);
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var chbText = ((CheckBox)sender).Content.ToString();
            DayOfWeek dayOfWeek;
            Enum.TryParse(chbText, out dayOfWeek);
            var minDate = dpFrom.DisplayDateStart ?? DateTime.MinValue;
            var maxDate = dpFrom.DisplayDateEnd ?? DateTime.MaxValue;
            for (var d = minDate; d <= maxDate ; d = d.AddDays(1))
            {
                if (d.DayOfWeek == dayOfWeek)
                {
                    dpFrom.BlackoutDates.Add(new CalendarDateRange(d));
                }
            }
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var chbText = ((CheckBox)sender).Content.ToString();
            DayOfWeek dayOfWeek;
            Enum.TryParse(chbText, out dayOfWeek);
            var minDate = dpFrom.DisplayDateStart ?? DateTime.MinValue;
            var maxDate = dpFrom.DisplayDateEnd ?? DateTime.MaxValue;
            for (var d = minDate; d <= maxDate ; d = d.AddDays(1))
            {
                if (d.DayOfWeek == dayOfWeek)
                {
                    dpFrom.BlackoutDates.Remove(dpFrom.BlackoutDates.First(item => item.Start == d ));
                }
            }
        }
