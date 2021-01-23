    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = "php";
    
        if (DropDownList1.Items.FindByText(TextBox1.Text) == null)    
        {
             DropDownList1.Items.Insert(0, new ListItem(TextBox1.Text));
        }
    
        if (DropDownList1.Text == TextBox1.Text)
        {
             DropDownList1.Text = TextBox1.Text;
        }
        else
        {
            TextBox2.Text = TextBox1.Text;
        }
    
    }
