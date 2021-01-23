    protected void btnCheckSelected_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string ids = row.Cells[1].Text;
                       
                        ListBox1.Items.Add(ids);
                    }
                }
            }
        }
