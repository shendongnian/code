     private void btnClickMe_Click(object sender, EventArgs e)
        {
          foreach (GridViewRow row in dgRD.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)row.FindControl("checker");
                if (chk.Checked)
                {
                    string ID = ((Label)row.FindControl("josemen1212")).Text;
                    //Run Sql statement to update db
                }
                else
                {
                    string ID = ((Label)row.FindControl("josemen1212")).Text;
                    //Run sql statement to update db
                }
            }
        }
        }
