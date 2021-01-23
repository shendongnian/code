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
               .Where(r => GetTime(r).Year == now.Year 
                        && GetTime(r).Month == now.Month);
    var weeklyRows = table.AsEnumerable()
               .Where(r => GetTime(r).Year == now.Year 
                        && GetTime(r).Week == now.Week);
    var monthlyTotalForCost = monthlyRows.GetTotalForCost();
    var monthlyTotalForHours = monthlyRows.GetTotalForHours();
    var weeklyTotalForCost = weeklyRows.GetTotalForCost();
    var weeklyTotalForHours = weeklyRows.GetTotalForHours();
