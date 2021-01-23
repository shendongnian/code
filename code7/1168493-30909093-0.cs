    table.Columns.Add("DateColumn", typeof(DateTime));
    foreach (DataRow row in table.Rows)
    {
        string dateStr = row.Field<string>("Date");
        string hoursStr = row.Field<string>("Hours");
        string minutesStr = row.Field<string>("Minutes");
        DateTime date; int hours; int minutes;
        if (DateTime.TryParseExact(dateStr, "MM/dd/YYYY", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)
            && int.TryParse(hoursStr, out hours) && int.TryParse(minutesStr, out minutes))
        {
            row.SetField("DateColumn", new DateTime(date.Year, date.Month, date.Day, hours, minutes, 0));
        }
    }
    table = table.AsEnumerable().OrderBy(row => row.Field<DateTime>("DateColumn")).CopyToDataTable();
