    protected void btnSrch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text.Length > 0)
        {
            dtSearch = dtInitialDatable;//the datatable that was bound to my DatagridView 
            dv = new DataView(dtSearch);
            dv.RowFilter = "Data_Column_Name LIKE '%" + txtSearch.Text.ToUpper() + "%'";
            //bind the DataGridView to dv 
            myDataGridView.DataSource = dv;
            //myDataGridView.DataBind();//uncomment if you are doing this in webform
        }
        else
        {
            dtSearch = null;
            dv = null;
        }
    }
