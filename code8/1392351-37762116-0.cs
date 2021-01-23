            if (row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.CheckBox chkrow = (row.Cells[0].FindControl("chkrow") as System.Web.UI.WebControls.CheckBox);
                if (chkrow.Checked)
                {
                   strname = GridView1.Rows[row.RowIndex].Cells[1].Text.ToString();
                }
            }
        }
