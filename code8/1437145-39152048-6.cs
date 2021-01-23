    protected void clearFields_btn(object sender, EventArgs e)
    {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox tb = GridView1.Rows[i].FindControl("User1TextAccountNumber") as TextBox;
                tb.Text = "";
            }
    }
