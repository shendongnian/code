    int year = 2016; // 366 days in 2016 because leap year
    DateTime yearStart = new DateTime(year, 1, 1);
    int daysInYear = (yearStart.AddYears(1) - yearStart).Days; // 366
    var oddSaturdays = Enumerable.Range(0, daysInYear)
        .Select(day => yearStart.AddDays(day))
        .Where(date => date.Day % 2 == 1 && date.DayOfWeek == DayOfWeek.Saturday);
    foreach (DateTime oddSaturday in oddSaturdays)
    { 
        // ...
        string sql = string.Format("INSERT INTO {0}.[WEEKEND] ([DATE],[DAYNAME]) VALUES (@DATE, @DAYNAME)", schemaname);
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = oddSaturday;
            cmd.Parameters.Add("@DAYNAME", SqlDbType.VarChar).Value = oddSaturday.DayOfWeek.ToString();
            int insrted = cmd.ExecuteNonQuery();
        }
        // ...
    }
