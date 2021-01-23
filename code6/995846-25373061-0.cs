	private void Status_SelectedIndexChanged(object sender, EventArgs e)
	{
        object oStatus = new object();
        oStatus = ((ComboBox)sender).SelectedItem;
        if (oStatus != null && !Convert.IsDBNull(oStatus))
        {
            SendKeys.Send("{TAB}");
            if (((int)oStatus) != 1)
            {
                tbl_TransactionsDataGridView.CurrentRow.Cells["CheckInEmployee"].Value = Environment.UserName;
                tbl_TransactionsDataGridView.CurrentRow.Cells["CloseDate"].Value = DateTime.Now;
            }
			else
            {
                tbl_TransactionsDataGridView.CurrentRow.Cells["CheckOutEmployee"].Value = Environment.UserName;
                tbl_TransactionsDataGridView.CurrentRow.Cells["CheckInEmployee"].Value = null;
                tbl_TransactionsDataGridView.CurrentRow.Cells["CloseDate"].Value = null;
            }
        }
    }
