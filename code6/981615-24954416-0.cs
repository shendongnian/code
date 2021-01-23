    string myLabelsName = column.ToString();
    LinkButton myButton = new LinkButton();
    myButton.Text = "THIS IS MY BUTTON";
    myButton.CommandName = myLabelsName;
    myButton.Click += new System.EventHandler(myButton_Click);
    // ...
    protected void myButton_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton) sender;
        string myLabelsName = btn.CommandName;
        Response.Redirect(myLabelsName + ".aspx");
    }
