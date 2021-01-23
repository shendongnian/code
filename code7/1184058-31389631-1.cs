    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           int rowindex = Convert.ToInt32(e.CommandArgument);
           string str = grid1.Rows[rowindex].Cells[0].Text;
           Session["Subject"] = str;
        }
