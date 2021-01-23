    string input = textbox_1.Text;
    DateTime inputTime;
    if (DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out inputTime))
    {
          DateTime outputTime=inputTime.AddHours(8).AddMinutes(40);
          textbox_2.Text = outputTime.ToString("HH:mm");
    }
