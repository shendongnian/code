    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool isEdit = false;
                // check for the condition to determine the state of the row
                if (isEdit)
                {
                    e.Row.RowState = DataControlRowState.Edit;
                }
            }
        }
