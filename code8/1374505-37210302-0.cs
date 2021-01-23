    DataTable dt = new DataTable();
    dt.Columns.Add("LOB");
    dt.Columns.Add("Quantity");
    dt.Columns.Add("Name");
    dt.Columns.Add("Packing");
    dt.Columns.Add("Price");
    dt.Columns.Add("Code");
    private void btnADD_Click(object sender, EventArgs e)
    {
        DataRow dr;
        
        for(int i = 0; i <= RowsCountThatYouWantToIsert; i++)
        {
            dr = dt.NewRow();
            dr["LOB"] = txtLOB.Text;
            dr["Quantity"] = txtQuantity.Text;
            dr["Name"] = txtName.Text;
            dr["Packing"] = txtPacking.Text;
            dr["Price"] = txtPrice.Text;
            dr["Code"] = txtBachNo.Text;
            dt.Rows.Add(dr);
        }
        
        gridviewDtaInserted.DataSource = dt; 
    }
