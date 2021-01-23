    table.Columns.Add("DateColumn", typeof(DateTime));
    foreach (DataRow row in table.Rows)
    {
        string dateTimeString = String.Format("{0} {1}:{2}",
            row.Field<string>("Date"),
            row.Field<string>("Hours"),
            row.Field<string>("Minutes"));
        DateTime date;
        if(DateTime.TryParseExact(dateTimeString, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date));
        {
            row.SetField("DateColumn", date);
        }
    }
    table = table.AsEnumerable()
        .OrderBy(row => row.Field<DateTime>("DateColumn"))
        .CopyToDataTable();
