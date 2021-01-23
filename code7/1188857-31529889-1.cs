    protected void Page_Load(object sender, EventArgs e)
    {
        refDate = new DateTime(1996, 7, 15);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            if (DateTime.Parse(e.Row.Cells[3].Text) < refDate)
            {
                e.Row.Cells[3].BackColor = Color.Red;
            }
        }
    }
