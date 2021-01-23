    monthComboBox.DataSource = CultureInfo.InvariantCulture.DateTimeFormat
                                                         .MonthNames.Take(12).ToList();
    monthComboBox.SelectedItem = CultureInfo.InvariantCulture.DateTimeFormat
                                            .MonthNames[DateTime.Now.AddMonths(-1).Month - 1];
    yearComboBox.DataSource = Enumerable.Range(1983, DateTime.Now.Year - 1983 + 1).ToList();
    yearComboBox.SelectedItem = DateTime.Now.Year;
