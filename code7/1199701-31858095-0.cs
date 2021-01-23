    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = "A";
        TextBox2.Text = "M";
        SqlDataSource1.FilterExpression = "ContactName like '{0}%' and City like '{1}%'";
        ControlParameter control1 = new ControlParameter();
        control1.Name = "ContactName";
        control1.ControlID = "TextBox1";
        control1.PropertyName = "Text";
        control1.ConvertEmptyStringToNull = true;
        SqlDataSource1.FilterParameters.Add(control1);
        ControlParameter control2 = new ControlParameter();
        control2.Name = "City";
        control2.ControlID = "TextBox2";
        control2.PropertyName = "Text";
        control2.ConvertEmptyStringToNull = true;
        SqlDataSource1.FilterParameters.Add(control2);
    }
