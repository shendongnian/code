    public class SingleItem : IDataItem
    {
      public SingleItem(DataTable table)
      {
        if (table.Rows.Count >= 1)
        {
          var row = table.Rows[0];
          SetData(row);
        }
        else
        {
          throw new ArgumentException("No rows.", "table");
        }
      }
      public abstract void SetData(DataRow row);
    }
    public AuditMethodSummaryData : SingleItem
    {
      public AuditMethodSummaryData(DataTable table) : base(table)
      {}
      public override void SetData(DataRow row) { /*...*/ }
    }
