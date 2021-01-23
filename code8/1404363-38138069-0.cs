    private void UpdateRecord(int transactionID, string status)
    {
        //Put your update code here
    }
    protected void btnGetSelected_Click(object sender, EventArgs e)
    {
        CheckBox chkSelect;
        int transactionID; //Or use whatever datatype this should be
        foreach (GridViewRow gridViewRow in GridView1.Rows)
        {
            chkSelect = (CheckBox)gridViewRow.FindControl("chkSelect");
            transactionID = (int)GridView1.DataKeys[gridViewRow.RowIndex].Value;
            if (chkSelect.Checked)
            {
                UpdateRecord(transactionID, "Approved");
            }
        }
    }
