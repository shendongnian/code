    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.PreviousPage != null)
        {
            int rowIndex = int.Parse(Request.QueryString["RowIndex"]);
            GridView GridView1 = (GridView)this.Page.PreviousPage.FindControl("GridView1");
            GridViewRow row = GridView1.Rows[rowIndex];
            //Since you use Bound Fields, use row.Cells[] to read values
            String Column_One_Value = row.Cells[0].Text;
            String Column_Two_Value = row.Cells[1].Text;
        }
    }
