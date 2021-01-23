    DateTime date = new DateTime(int.Parse(year.Text), int.Parse(month.Text), 1); //year.Text & month.Text are just the month and year from controls in the form.
    for (int j = 7; j < daysInMonth + 7; j++)
    {
        Range cell = sheet.get_Range("A" + j);
        cell.Value = convertDateTime(date);
        cell.NumberFormat = "DD/MM/YYYY";
        date = date.AddDays(1.0);
    }
    
