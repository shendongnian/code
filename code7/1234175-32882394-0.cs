    protected void txtaddNum_TextChanged(object sender, EventArgs e)
    {
        foreach (GridDataItem dataItem in grdAddGoals.MasterTableView.Items)
        {
            TextBox txtQuantity = (TextBox)dataItem.FindControl("txtCommitment");
            txtQuantity.Text = txtaddNum.Text;
        }
    }
