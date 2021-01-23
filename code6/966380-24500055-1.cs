    protected void rbt_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if ((sender as CheckBox).ClientID == (row.FindControl("rbt") as CheckBox).ClientID)
            {
                string checkboxValue = (row.FindControl("rbt") as CheckBox).Checked.ToString();
                string textboxValue = (row.FindControl("TextBox1") as TextBox).Text;
                // you could get all of the selected row's values the same as above code.
                break; //break the loop once it finds the result
            }
        }
    }
