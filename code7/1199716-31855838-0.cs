    var sb = new StringBuilder();
    foreach (DataRow row in dt.Rows)
    {
        foreach (DataColumn col in dt.Columns)
        {
            sb.Append(Convert.ToString(row[col])));
            sb.Append(" ");
        }
    }
    var fullString = sb.ToString();
