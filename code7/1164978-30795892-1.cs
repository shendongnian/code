    public static class TableLinqHelper
    {
        public static T SumOfTableColumn<T>(this IEnumerable<DataRow> rows, string columnName)
        {
            return rows.Sum(r => r.Field<T>(columnName));
        }
    }
    var monthlyRows = table.AsEnumerable()
               .Where(r => r.Field<DateTime>("ColumnName").Year == now.Year 
                        && r.Field<DateTime>("ColumnName").Month == now.Month);
    var weeklyRows = table.AsEnumerable()
               .Where(r => r.Field<DateTime>("ColumnName").Year == now.Year 
                        && r.Field<DateTime>("ColumnName").Week == now.Week);
    var monthlyTotalForCost = monthlyRows.SumOfTableColumn<decimal>("CostColumn");
    var monthlyTotalForHours = monthlyRows.SumOfTableColumn<double>("HoursColumn");
    var weeklyTotalForCost = weeklyRows.SumOfTableColumn<decimal>("CostColumn");
    var weeklyTotalForHours = weeklyRows.SumOfTableColumn<double>("HoursColumn");
