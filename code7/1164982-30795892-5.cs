    public static class TableLinqHelper
    {
        public static SumOfTableColumn<T>(this IEnumerable<DataRow> rows, string columnName)
        {
            return rows.Sum(r => r.Field<T>(columnName));
        }
        public static DateTime GetDate(this DataRow row)
        {
            return row.Field<DateTime>("DateColumn");
        }
        public static GetTotalForCost(this IEnumerable<DataRow> row)
        {
            return SumOfTableColumn<decimal>(row, "CostColumn");
        }
        public static GetTotalForHours(this IEnumerable<DataRow> row)
        {
            return SumOfTableColumn<double>(row, "HoursColumn");
        }
    }
    var monthlyRows = table.AsEnumerable()
               .Where(r => r.GetTime().Year == now.Year 
                        && r.GetTime().Month == now.Month);
    var weeklyRows = table.AsEnumerable()
               .Where(r => r.GetTime().Year == now.Year 
                        && r.GetTime().Week == now.Week);
    var monthlyTotalForCost = monthlyRows.GetTotalForCost();
    var monthlyTotalForHours = monthlyRows.GetTotalForHours();
    var weeklyTotalForCost = weeklyRows.GetTotalForCost();
    var weeklyTotalForHours = weeklyRows.GetTotalForHours();
