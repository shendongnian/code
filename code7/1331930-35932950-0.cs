       protected void lnkbtn_Previous_Click(object sender, EventArgs e)
       {
           foreach (GridViewRow row in Employeedob.Rows)
           {
           var chk = row.FindControl("CheckBox2") as CheckBox;
           chk.Visible = false;
           }
       }
