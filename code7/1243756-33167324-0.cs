    DateTime date = DateTime.Parse(textBox2.Text);
    // Find Monday of the week of textBox2.
    DateTime first = date.AddDays(-(date.DayOfWeek - DayOfWeek.Monday + 7) % 7);
    // Find Sunday of the week of textBox2.
    DateTime last = date.AddDays((DayOfWeek.Sunday - date.DayOfWeek + 7) % 7);
    
    string startDate = first.ToString("yyyy'/'MM'/'dd");
    string endDate = last.ToString("yyyy'/'MM'/'dd");
