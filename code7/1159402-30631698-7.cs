    public partial class _Default : Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("You have successfully added a Person!");
            bool gender = (DropDownList1.SelectedValue == "Male") ? true:false;
            Person p = new Person(TextBox1.Text, Convert.ToInt32(TextBox2.Text), 
            TextBox3.Text, TextBox4.Text, gender, TextBox5.Text);
            Label1.Text = (p.PresentPerson());
        }
    }
