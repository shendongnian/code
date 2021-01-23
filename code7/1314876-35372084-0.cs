    private void deleteRowsBtn_Click(object sender, EventArgs e)
    {
        string delId;
        BSRecords deleteRecord;
        foreach (DataGridViewRow item in this.bSRecordsDataGridView.SelectedRows)
        {
            bSRecordsDataGridView.Rows.RemoveAt(item.Index);
            // code to remove record from database
            delId = item.Cells[0].Value.ToString();  // column that has id field
            deleteRecord = db.BSRecords.First(b => b.Id == delId);    // get the record. will throw exception if not found.
            db.BSRecords.Remove(deleteRecord);
        }
        db.SaveChanges();
        bSRecordsDataGridView.DataBind();   // this will refresh your grid. Do same in save.
    }
