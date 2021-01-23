    protected void Button_Example_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow s in GridView_Staff.Rows)
        {
            CheckBox CheckBox_Staff = (s.FindControl("CheckBox_Staff") as CheckBox);
            if (CheckBox_Staff.Checked == true)
            {
                string text = s.Cells[2].Text;
                string pattern =  @"(?<=<[^<>]+)\s+(?:href)\s*=\s*([""']).*?\1";
                text = System.Text.RegularExpressions.Regex.Replace(text, pattern, "", RegexOptions.IgnoreCase);
                s.Cells[2].Text = text;
                Response.Write("<script>alert('" + s.Cells[2].Text + "');</script>");
            }
        }
    }
