    protected void Page_Load(object sender, EventArgs e)
    {
        minDate = new DateTime(1996, 7, 7);
        maxDate = new DateTime(1996, 7, 15);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            var curDate = DateTime.Parse(e.Row.Cells[3].Text);
            if (minDate < curDate && curDate < maxDate)
            {
                e.Row.Cells[3].BackColor = Color.Red;
                e.Row.Cells[3].ForeColor = Color.White;
            }
        }
    }
