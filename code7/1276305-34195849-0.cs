    protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                string isActive = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "isActive"));
    
                if (isActive == "0")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#28b779");//81F79F
                    e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }
                else
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#da5554");//F78181
                    e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }
