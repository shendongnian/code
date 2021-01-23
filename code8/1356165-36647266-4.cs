    protected void DeletingRow(int rowIndex)
    {
        DataTable t = (DataTable)Session["MyDataTable"];
        t.Rows.RemoveAt(rowIndex);
        GridView2.DataSource = t;
        GridView2.DataBind();
    }
