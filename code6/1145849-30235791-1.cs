    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                // Just return in case GridView is rendering in Edit Mode
                if (GridView1.EditIndex >= 0)
                    return;
                
                // In case GridView is rendering in Normal state
                // Hide the Columns you don't want to display
                if ((e.Row.RowState == DataControlRowState.Normal ||
                     e.Row.RowState == DataControlRowState.Alternate) &&
                ( e.Row.RowType == DataControlRowType.DataRow || 
                  e.Row.RowType == DataControlRowType.Header))
                {
                    // Hide the Password Column
                    e.Row.Cells[2].Visible = false;
                }
            }
 
