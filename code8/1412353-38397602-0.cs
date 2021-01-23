    protected void Page_Load(object sender, EventArgs e)
    {
        var button = new Button {ID = "Button1", Text = "Test Button"};
        button.Click += button_Click;
        PlaceHolder1.Controls.Add(button);
    }
    
    private void button_Click(object sender, EventArgs e)
    {
        testdiv.InnerHtml = "Button1 is clicked";
    }
