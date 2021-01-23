    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = "php";
    
        if (DropDownList1.Items.FindByText(TextBox1.Text) != null)    
        {
             DropDownList1.Text = TextBox1.Text;
        }
        else
        {
            TextBox2.Text = TextBox1.Text;
        }
    
    }
