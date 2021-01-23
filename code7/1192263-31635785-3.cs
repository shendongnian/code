    protected void btnDisplay_Click(object sender, EventArgs e)
        {
       string data = "";
    
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string yourFirstRowCell = row.Cells[1].Text;
                        string yourSecondRowCell = row.Cells[2].Text;
                        string yourThirdRowCell = row.Cells[3].Text;
                        data = yourFirstRowCell + yourSecondRowCell + yourThirdRowCell; 
                    }
                }
            }
         textboxDataDisplay.text = data; 
    }
