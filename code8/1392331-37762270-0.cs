    foreach (GridViewRow row in GridView1.Rows)
    {
     if (row.RowType == DataControlRowType.DataRow)
       {
        System.Web.UI.WebControls.CheckBox chkrow = (row.Cells[0].FindControl("chkrow") as System.Web.UI.WebControls.CheckBox);
        if (chkrow.Checked)
         {
          string Username = dgvshow.Rows[row.RowIndex].Cells[1].Text.ToString()
          Approve(Username);
                    
         }
      }
    }
