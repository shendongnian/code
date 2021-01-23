        protected void DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkSelect = ((CheckBox)GridView1.Rows[i].FindControl("chkSelect"));
         
                if (DDL.SelectedIndex != 0)
                {
                    chkSelect.Enabled = true;
                }
            }
        }
