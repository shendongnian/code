    public void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DaTable t = (DataTable)Session["MyDataTable"];
        TextBox1.Text=GridView2.Rows[e.NewEditIndex].Cells[1].Text.ToString();
        DropDownList1.Text =   GridView2.Rows[e.NewEditIndex].Cells[2].Text.ToString();
        GridView2.EditIndex = -1;
        GridView2.DataSource = t;
        GridView2.DataBind();
        //CAN I CALL HERE GRIDVIEW_ROW_DELETING METHOD,I try but problem is arguemnts etc
        DeletingRow(GridView2.CurrentRow.Index);
    }
