    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("You have successfully added a Person!");
        int age;
        bool gender;
        int.TryParse(TextBox2.Text.ToString(), out age);
        bool.TryParse(DropDownList1.SelectedValue, out gender);
        Person p = new Person(TextBox1.Text, age, TextBox3.Text, TextBox4.Text, gender, 
                        TextBox5.Text);
    }
