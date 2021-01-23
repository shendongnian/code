          for (int i = 0; i < GridView1.Rows.Count; i++)
          {
            CheckBox checkboxdelete = ((CheckBox)GridView1.Rows[i].FindControl("checkboxdelete"));
            if (checkboxdelete.Checked == true)
            {
                //Your Code
            }
          }
