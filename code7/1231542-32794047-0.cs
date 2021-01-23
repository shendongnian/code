    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
    					int idColumnNumber=1; // number of your id column
        				int id=Convert.ToInt32(e.Row.Cells[idColumnNumber].Text);
                        (e.Row.FindControl("lnkEdit") as Button).Attributes.Add("onClick", "ShowEditModal('" + id + "');");
        
                    }
                }
