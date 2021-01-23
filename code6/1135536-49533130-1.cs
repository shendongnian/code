    private void orderpurchasegridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = orderpurchasegridview.Rows[ind];
            txtorderid.Text = selectedRows.Cells[0].Value.ToString();
            cmbosuppliername.Text = selectedRows.Cells[1].Value.ToString();
            cmboproductname.Text = selectedRows.Cells[2].Value.ToString();
            txtdate.Text = selectedRows.Cells[3].Value.ToString();
            txtorderquantity.Text = selectedRows.Cells[4].Value.ToString();
    }
