        private const int ROW_00 = 0;
        private const int ROW_11 = 11;
        protected void MergeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var index = e.Row.RowIndex;
                if ((index == ROW_00) || (index == ROW_11))
                {
                    e.Row.BackColor = System.Drawing.Color.Aqua;
                }
            }
        }
