    void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                JobPieceSerialNo item = e.Row.DataItem as JobPieceSerialNo;
                if (item != null)
                {
                    if (string.IsNullOrEmpty(item.Reason))
                    {
                        e.Row.Visible = false;
                    }
                }
            }
        }
