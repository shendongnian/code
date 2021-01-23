    public class DataTableExt: DataTable
    {
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new DataRowExt(builder);
        }
        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            // row has changed, notifying about changes
            var r = e.Row as DataRowExt;
            if (r!= null)
                r.OnRowStateChanged();
        }
    }
