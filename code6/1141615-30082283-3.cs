    private void GetIndexes()
    {
        this.SelectRowIndexes = new List<int>();
        for (int i = 0; i < gridViewRecords.Rows.Count; i++)
        {
            DataRowView drv = (DataRowView)gridViewRecords.CurrentRow.DataBoundItem;
            DataRow selectedRow = drv.Row;
            ResourceKey = Convert.ToInt32(selectedRow["ResourceAndInstallKey"]);
            this.SelectRowIndexes.Add(ResourceKey);
        }
    }
