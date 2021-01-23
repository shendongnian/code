    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    if (e.Row.DataItem != null)
                    {
                        DateTime dt = (DateTime)DataBinder.Eval(e.Row.DataItem, "creationDate");
                        e.Row.Cells[GetColumnByID("Year")].Text = dt.Year.ToString();
                    }
                }
                catch (System.Exception ex)
                {
                    Response.Write("** " + ex.Message);
                }
            }
        }
