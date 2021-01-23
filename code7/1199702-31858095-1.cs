    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = "A";
        TextBox2.Text = "M";
        SqlDataSource1.FilterExpression = "ContactName like '{0}%' and City like '{1}%'";
        SqlDataSource1.FilterParameters.Add(new ControlParameter("ContactName", "TextBox1", "Text"));
        SqlDataSource1.FilterParameters.Add(new ControlParameter("City", "TextBox2", "Text"));
    }
