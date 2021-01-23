    DateTime date = new DateTime(int.Parse(year.Text), int.Parse(month.Text), 1);
    for (int j = 0; j < daysInMonth; j++)
    {
       // Skip increasing the first date
       if (j > 0) {
          date.AddDays(1.0);
       }
       // Set the correct date to the sheet
       sheet.get_Range("A" + (j + 7)).Value = date.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
