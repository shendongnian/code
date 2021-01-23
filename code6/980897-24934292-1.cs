    protected void gvPetrols_RowDataBound(object sender, GridViewRowEventArgs e)
    {        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {     
            if (e.Row.Cells[0].Text == "7/22/2014")
            {
                e.Row.ForeColor = System.Drawing.Color.FromName("#E56E94");                
            }
            else
            {
                //Other styles
            }
        }    
    }
