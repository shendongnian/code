    textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    var source = new AutoCompleteStringCollection();
    source.AddRange(System.Globalization.CultureInfo
                          .InvariantCulture.DateTimeFormat.MonthNames);
    textBox1.AutoCompleteCustomSource = source;
