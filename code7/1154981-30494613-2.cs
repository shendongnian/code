    public static class Extensions
    {
        public static string ToText(this DataRow dr)
        {
            string output = "";
            output = dr.Table.Columns.Cast<DataColumn>()
                       .Aggregate(output, (current, c) => current +
                           string.Format("{0}='{1}'", c.ColumnName, (string)dr[c]));
            return output;
        }
        public static string ToText(this DataTable table)
        {
            return table.Rows.Cast<DataRow>()
                        .Aggregate("", (current, dr) => current + dr.ToText() + Environment.NewLine);
        }
    }
