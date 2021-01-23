    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostback)
        {
            Literal myText = new Literal() 
            { 
                Text = "some text" 
            };
            Content2.Controls.Add(myText);
        }
    }
