    public static class Extensions
    {
        public static DataTable DataTable(this DataGridView sender)
        {
            return ((DataTable)sender.DataSource);
        }
        public static EnumerableRowCollection<DataRow> DataTableEnumerable(this DataGridView sender)
        {
            return ((DataTable)sender.DataSource).AsEnumerable();
        }
    }
