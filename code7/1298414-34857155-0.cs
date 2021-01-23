      protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("q1_svar1");
                if (chk.Checked)
                {
                    //Your code ...
                }
            }
        }
