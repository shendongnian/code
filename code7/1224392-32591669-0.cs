    DateTime dParsedDate;
    if (!DateTime.TryParseExact(sDateTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dParsedDate))
    textBox2.Text = "ERROR";
    else
    textBox2.Text = dParsedDate.ToString();
