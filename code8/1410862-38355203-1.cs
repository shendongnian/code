    public static class DataGridViewExtensions
    {
        public static List<DataRow> ToDataRows(this DataGridViewSelectedRowCollection Rows)
        {
            if (Rows == null || Rows.Count == 0)
                return null;
            return Rows.Cast<DataGridViewRow>()
                       .Where(x => x.DataBoundItem is DataRowView)
                       .Select(x => ((DataRowView)(x.DataBoundItem)).Row).ToList();
        }
    }
