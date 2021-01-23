        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<string> selectedRows = this.HiddenSelectedRows.Value.Split(',').ToList();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (selectedRows.Contains(e.Row.Cells[1].Text))
                {
                    CheckBox chk = (CheckBox)e.Row.FindControl("cbSelect");
                    chk.Checked = true;
                }
            }
        }
