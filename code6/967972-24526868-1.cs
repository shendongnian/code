    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlInputHidden hidden2 = new HtmlInputHidden();
        hidden2.ID = "Here you will put the id of the control";
        hidden2.Value = "Here you will put your value";
        this.Controls.Add(hidden2);
    }
