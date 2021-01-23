    protected void btnProcess_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string strname = string.Empty;
            string edu = string.Empty;
            string location = string.Empty;
            foreach (GridViewRow gvrow in gvDetails.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");
                if (chk != null & chk.Checked)
                {
                   //To Fetch the row index
                    //str += gvDetails.SelectedIndex.ToString();
                    
                    //To Fetch the value of Selected Row.
                    str += gvDetails.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                    strname += gvrow.Cells[2].Text + ',';
                    edu += gvrow.Cells[3].Text + ',';
                    location += gvrow.Cells[4].Text + ',';
                }
            }
            str = str.Trim(",".ToCharArray());
            strname = strname.Trim(",".ToCharArray());
            lblmsg.Text = "Selected UserIds: <b>" + str + "</b><br/>" + "Selected UserNames: <b>" + strname + "</b><br>" + " Education: <b>" + edu + "</b><br>" + " Location: <b>" + location + "</b><br>";
        }
    }
