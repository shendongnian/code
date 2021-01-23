    protected void GrdidView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView) e.Row.DataItem).Row;
            string htmlColor = row.Field<string>("border_color");
            Color borderColor = System.Drawing.ColorTranslator.FromHtml(htmlColor);
            ImageButton btn = (ImageButton) e.Row.FindControl("ImageButtonID");
            btn.BorderColor = borderColor;
        }
    }
