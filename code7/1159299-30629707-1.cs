    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("You have successfully added a Person!");
        Person p = new Person(TextBox1.Text, int.Parse(TextBox2.Text.ToString()), 
            TextBox3.Text, TextBox4.Text, bool.Parse(DropDownList1.SelectedValue.ToString()), 
            TextBox5.Text);
    }
